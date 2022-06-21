using Microsoft.AspNetCore.Mvc;
using test2_retake.Services;

namespace test2_retake.Controllers;

[Route("api/firetruck")]
[ApiController]
public class FireTruckController : ControllerBase
{
    private IDbService _service;

    public FireTruckController(IDbService service)
    {
        _service = service;
    }

    [HttpGet("IdFiretruck")]
    public IActionResult GetFireTruck(int IdFireTruck)
    {
        var result = _service.GetFireTruck(IdFireTruck);
        return Ok();
    }
}