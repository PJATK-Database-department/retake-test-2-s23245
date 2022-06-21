using Microsoft.AspNetCore.Mvc;
using test2_retake.Services;

namespace test2_retake.Controllers;

[Route("api/action")]
[ApiController]
public class ActionController : ControllerBase
{
    private IDbService _service;

    public ActionController(IDbService service)
    {
        _service = service;
    }

    [HttpPut("idAction")]
    public IActionResult UpdateActionEndDate(int idAction,DateTime endTime)
    {
        if (_service.CheckIdAction(idAction) == false)
            return BadRequest("NOT PROPER ID");

        if (_service.CheckProperOfEndtime(idAction,endTime) == false)
            return BadRequest("NOT PROPER END TIME");

        if (_service.CheckPresentsOfEndTime(idAction, endTime) == false)
            return NoContent();
        
        _service.UpdateActionEndDate(idAction,endTime);
        return Ok();
    }
}