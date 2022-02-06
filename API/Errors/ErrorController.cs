using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace API.Errors;

[Route("errors/{code}")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : BaseApicontroller
{
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ApiResponse(code));
    }
}
