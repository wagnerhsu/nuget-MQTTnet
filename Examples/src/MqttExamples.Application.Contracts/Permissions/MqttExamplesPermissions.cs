using Volo.Abp.Reflection;

namespace MqttExamples.Permissions
{
    public class MqttExamplesPermissions
    {
        public const string GroupName = "MqttExamples";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(MqttExamplesPermissions));
        }
    }
}