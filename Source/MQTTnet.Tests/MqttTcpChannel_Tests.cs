// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MQTTnet.Implementations;

namespace MQTTnet.Tests;

[TestClass]
public class MqttTcpChannel_Tests
{
    [TestMethod]
    public async Task Dispose_Channel_While_Used()
    {
        using var ct = new CancellationTokenSource();
        using var serverSocket = new CrossPlatformSocket(AddressFamily.InterNetwork, ProtocolType.Tcp);

        try
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 50001));
            serverSocket.Listen(0);

#pragma warning disable 4014
            Task.Run(
                async () =>
#pragma warning restore 4014
                {
                    while (!ct.IsCancellationRequested)
                    {
                        var client = await serverSocket.AcceptAsync(CancellationToken.None);
                        var data = new byte[] { 128 };
                        await client.SendAsync(new ArraySegment<byte>(data), SocketFlags.None);
                    }
                },
                ct.Token);

            var remoteEndPoint = new DnsEndPoint("localhost", 50001);
            using var clientSocket = new CrossPlatformSocket(AddressFamily.InterNetwork, ProtocolType.Tcp);
            await clientSocket.ConnectAsync(remoteEndPoint, CancellationToken.None);

            var tcpChannel = new MqttTcpChannel(clientSocket.GetStream(), remoteEndPoint, null);

            await Task.Delay(100, ct.Token);

            var buffer = new byte[1];
            await tcpChannel.ReadAsync(buffer, 0, 1, ct.Token);

            Assert.AreEqual(128, buffer[0]);

            // This block should fail after dispose.
#pragma warning disable 4014
            Task.Run(
                () =>
#pragma warning restore 4014
                {
                    Task.Delay(200, ct.Token);
                    tcpChannel.Dispose();
                },
                ct.Token);

            try
            {
                await tcpChannel.ReadAsync(buffer, 0, 1, CancellationToken.None);
            }
            catch (Exception exception)
            {
                Assert.IsInstanceOfType(exception, typeof(SocketException));
                Assert.AreEqual(SocketError.OperationAborted, ((SocketException)exception).SocketErrorCode);
            }
        }
        finally
        {
            ct.Cancel(false);
        }
    }
}