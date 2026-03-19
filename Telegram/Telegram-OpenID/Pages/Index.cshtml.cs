using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Telegram_OpenID.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public void SendMessageToMe(string message)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.telegram.org/bot<token>/sendMessage");
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("chat_id", "-###########"));
            collection.Add(new("text", message));
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            var response = client.SendAsync(request).Result;
        }

        [Authorize(Roles="admin")]
        public IActionResult OnPost(string message)
        {
            var myUser = User.Identity?.Name;
            SendMessageToMe(message);
            return RedirectToPage();
        }
    }
}
