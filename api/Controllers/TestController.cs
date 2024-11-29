using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    public TestController()
    {

    }

    [HttpGet("GetData")]
    public ActionResult GetDataFromDB(string name, string lastName)
    {
        return Ok(name);
    }

    [HttpGet("GetDAba")]
    public ActionResult GetDB(string name, string lastName)
    {
        return Ok(name);
    }
}