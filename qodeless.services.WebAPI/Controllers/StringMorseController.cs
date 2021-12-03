using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.IO;
using Renci.SshNet.Messages;

namespace qodeless.services.WebAPI.Controllers
{
    class WriteAllText
    {
        [HttpPost]
        [Route("Message/[Model]")]
        public static async Task ExampleAsync()
        {
            string text = "hello World!";

            await File.WriteAllTextAsync("WriteText.txt", text);
        }
    }
}