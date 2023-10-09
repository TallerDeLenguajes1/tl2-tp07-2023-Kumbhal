using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AccesoADato;
using Tareas;
using ManejoTarea;

namespace ManejoTarea.Controllers;

[ApiController]
[Route("[controller]")]
public class ManejoTareaController : ControllerBase{
    private ManejoTareas manejoDT;
    private readonly ILogger<ManejoTareaController> _logger;
    public ManejoTareaController(ILogger<ManejoTareaController> logger){
        _logger = logger;
        manejoDT = ManejoTareas.GetInstance();
    }
    [HttpPost("PostTarea")]
    public ActionResult<Tarea> PostTarea(int idTarea, string? tituloTarea, string? descripcionTarea){
        Tarea tareaCreada = manejoDT.PostTarea(idTarea, tituloTarea, descripcionTarea);
        if (tareaCreada == null){
            return BadRequest();
        }
        return Ok(tareaCreada);
    }
    [HttpGet("GetTareaId")]
    public ActionResult<Tarea> GetTareaId(int idTarea){
        Tarea tareaBuscada = manejoDT.GetTareaId(idTarea);
        if (tareaBuscada == null){
            return BadRequest();
        }
        return Ok(tareaBuscada);
    }
    [HttpGet("GetListadoTareas")]
    public ActionResult<List<Tarea>> GetListadoTareas(){
        List<Tarea> listadoTareas = manejoDT.GetListadoTareas();
        if (listadoTareas == null){
            return BadRequest();
        }
        return Ok(listadoTareas);
    }
    [HttpGet("GetListadoTareasCompletadas")]
    public ActionResult<List<Tarea>> GetListadoTareasCompletadas(){
        List<Tarea> listadoTareas = manejoDT.GetListadoTareasCompletadas();
        if (listadoTareas == null){
            return BadRequest();
        }
        return Ok(listadoTareas);
    }
}