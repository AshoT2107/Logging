using Logging.Languages;
using Logging.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoggerRepository logger;
        private readonly List<string> InfoUz = new() { "malumot1", "malumot2" };
        private readonly List<string> InfoEn = new() { "data1", "data2" };
        public UserController()
        {
            logger = new ConsoleLoggerRepository();
        }
        [HttpGet]
        public IActionResult GetInfo()
        {
            LanguageRequest.CurrentLanguage = Request.Headers["language"];
            logger.Add($"CurrentLanguage is {LanguageRequest.CurrentLanguage + (DateTime.Now)}");
            return LanguageRequest.CurrentLanguage switch
                {
                    "uz" => Ok(InfoUz),
                    "en" => Ok(InfoEn),
                    _ => throw new InvalidOperationException()
                };
                
        }
    }
}
