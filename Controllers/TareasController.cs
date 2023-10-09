using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AccesoADato;
using Tareas;
using ManejoTarea;

namespace Tareas.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase{
    private ManejoTareas manejoDT;
    private readonly ILogger<TareasController> _logger;
    public TareasController(ILogger<TareasController> logger){
        _logger = logger;
        AccesoADatos accesosADatos = new AccesoADatos();
        manejoDT = new ManejoTareas(accesosADatos);
    }
    [HttpPost("PostTarea")]
    public ActionResult<Tarea> PostTarea(int idTarea, string? tituloTarea, string? descripcionTarea){
        Tarea tareaCreada = manejoDT.PostTarea(idTarea, tituloTarea, descripcionTarea);
        if (tareaCreada == null){
            return BadRequest("No se creo la tarea.");
        }
        return Ok(tareaCreada);
    }
    [HttpGet("GetTareaId")]
    public ActionResult<Tarea> GetTareaId(int idTarea){
        Tarea tareaBuscada = manejoDT.GetTareaId(idTarea);
        if (tareaBuscada == null){
            return BadRequest("No existe la tarea.");
        }
        return Ok(tareaBuscada);
    }
    [HttpGet("MostrarTareas")]
    public ActionResult<List<Tarea>> MostrarTareas(){
        List<Tarea> listadoTareas = manejoDT.MostrarTareas();
        if (listadoTareas == null){
            return BadRequest("No hay tareas.");
        }
        return Ok(listadoTareas);
    }
    [HttpGet("GetListadoTareasCompletadas")]
    public ActionResult<List<Tarea>> GetListadoTareasCompletadas(){
        List<Tarea> listadoTareas = manejoDT.GetListadoTareasCompletadas();
        if (listadoTareas == null){
            return BadRequest("No hay tareas.");
        }
        return Ok(listadoTareas);
    }
}