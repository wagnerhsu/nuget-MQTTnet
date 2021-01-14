using MqttExamples.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MqttExamples.Permissions
{
    public class MqttExamplesPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MqttExamplesPermissions.GroupName, L("Permission:MqttExamples"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MqttExamplesResource>(name);
        }
    }
}