using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        //protected string RequestUser => Request.Headers["request_user"].ToString().ToLower();

        protected string RequestUser => "dudu245@live.com";

    }
}
