
using Microsoft.AspNetCore.Mvc;

namespace Bible.API.Controllers.Base
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        protected readonly T _service;
        public BaseController(T service)
        {
            _service = service;
        }

        protected IActionResult GetResponse(object data)
        {
            return Ok(new
            {
                Success = true,
                Items = data,
                TotalCount = data.GetType().GetProperty("Count")?.GetValue(data, null) ?? 0
            });
        }
        // response error
        protected IActionResult GetResponseError(string message)
        {
            return Ok(new
            {
                Success = false,
                Message = message
            });
        }
    }
}
