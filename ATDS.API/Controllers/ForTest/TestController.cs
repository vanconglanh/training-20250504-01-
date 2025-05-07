using ATDS.API.Helper;
using ATDS.API.Info;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ATDS.API.Controllers.ForTest
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        public TestController(IOptions<MultilanguageSettings> settings, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _sharedLocalizer = sharedLocalizer;
        }

        // GET: api/<TestController>
        [HttpGet]
        public string Get()
        {
            //return LanguageHelper.GetStringByLanguage("The Email field does not have a valid format.", _multilanguageSettings.DefaultLanguage);
            return _sharedLocalizer["The Email field is required."].Value;
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
