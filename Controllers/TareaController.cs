using System.Runtime.CompilerServices;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace TpRepasoTaller2.Controllers;

[ApiController]
[Route("Controllers")]
public class TareaController : ControllerBase
{
    private readonly ILogger<TareaController> _logger;
    private readonly ITareaRepository _tareaRepository;

    public TareaController(ILogger<TareaController> logger, ITareaRepository tareaRepository)
    {
        _logger = logger;
        _tareaRepository = tareaRepository;
    }


    [HttpPost("/api/Tarea")]
    public IActionResult CrearTarea([FromBody] Tarea tarea)
    {
        try
        {
            _tareaRepository.CrearTarea(tarea);
            return Ok("Tarea creada con exito");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"ERROR {ex.Message}");
        }
    }

    [HttpGet("/api/Tarea/{id}")]
    public ActionResult ObtenerTarea(int id)
    {
        try
        {
            Tarea tareaElegida = _tareaRepository.ObtenerTarea(id);
            return Ok(tareaElegida);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"ERROR {ex.Message}");
        }
    }

    [HttpPut("/api/Tarea/{id}")]
    public ActionResult ModificarTarea(int id, [FromBody] Tarea tarea)
    {
        try
        {
            _tareaRepository.ModificarTarea(id, tarea);
            return Ok("Tarea modificado satisfactoriamente");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"ERROR {ex.Message}");
        }
    }

    [HttpDelete("/api/Tarea/{id}")]
    public IActionResult EliminarTarea(int id)
    {
        _tareaRepository.EliminarTarea(id);
        return Ok("Producto eliminado con exito");
    }

    [HttpGet("/api/Tarea")]
    public ActionResult<List<Tarea>> ObtenerTareas(){
        try
        {
            List<Tarea> listaTarea = _tareaRepository.obtenerTareas();
            return Ok(listaTarea);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"ERROR {ex.Message}");
        }
    }

    [HttpGet("/api/Tarea/estado/{estado}")]
    public ActionResult<List<Tarea>> ObtenerTareasSegunEstado(EstadoTarea estado)
    {
        try
        {
            List<Tarea> listaTarea = _tareaRepository.ObtenerTareasSegunEstado(estado);
            return Ok(listaTarea);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"ERROR {ex.Message}");
        }
    }
}