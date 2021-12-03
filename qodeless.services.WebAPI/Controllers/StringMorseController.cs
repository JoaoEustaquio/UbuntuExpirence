using Microsoft.AspNetCore.Mvc;
using qodeless.services.WebApi.Model;
using System.Threading.Tasks;
using System.IO;
using Renci.SshNet.Messages;

namespace qodeless.services.WebAPI.Controllers
{
    [HttpGet]
    public IActionResult Message()
    public class StringMorseController 
    {
        [HttpPost("StringMorseController")]
        public string ReceiveMessage(MessageViewModel vm)
        {
            var message = vm.Name;
            return message;
    }
    [HttpPost]
    public IActionResult Morse()
        public static async Task ExampleAsync()
    {
        var Morse = 

            await File.WriteAllTextAsync("WriteText.txt", text);
        }
    }    
}