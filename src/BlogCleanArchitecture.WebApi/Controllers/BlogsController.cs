using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogCleanArchitecture.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            string message = "This is a test api.";
            return message;
        }
    }
}
