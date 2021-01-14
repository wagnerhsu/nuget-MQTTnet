using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace MqttExamples.Pages
{
    public class IndexModel : MqttExamplesPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}