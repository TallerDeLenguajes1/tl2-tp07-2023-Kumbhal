using AccesoADato;
using Tareas;

namespace ManejoTarea{
    public class ManejoTareas{
        private static ManejoTareas? instancia;
        private AccesoADatos? accesoADato;
        private List<Tarea>? listadoTareas;
        public List<Tarea>? ListadoTareas{get => listadoTareas;}
        public ManejoTareas(){}
        public static ManejoTareas GetInstance(){
            if(instancia == null){
                instancia = new ManejoTareas();
                instancia.CargarTareas();
            }
            return instancia;
        }
        public void CargarTareas(){
            listadoTareas = accesoADato?.CargarDatosTarea("Tareas.json");
        }
        public void GuardarTareas(){
            accesoADato?.GuardarDatosTarea(listadoTareas!);
        }
        public Tarea PostTarea(int idTarea, string? tituloTarea, string? descripcionTarea){
            Tarea tareaCreada = new Tarea(idTarea, tituloTarea, descripcionTarea);
            listadoTareas!.Add(tareaCreada);
            accesoADato!.GuardarDatosTarea(listadoTareas);
            return tareaCreada;
        }
        public Tarea GetTareaId(int idTarea){
            Tarea tareaBuscada = listadoTareas!.FirstOrDefault(tarea => tarea.GetIdTarea() == idTarea)!;
            return tareaBuscada;
        }
        public bool ActualizarTarea(int estadoTarea, int idTarea){
            Tarea tareaBuscada = GetTareaId(idTarea);
            if (tareaBuscada != null){
                if (tareaBuscada.ActualizarEstado(estadoTarea)){
                    accesoADato!.GuardarDatosTarea(listadoTareas!);
                    return true;
                }
            }
            return false;
        }
        public List<Tarea> EliminarTarea(int idTarea){
            Tarea tareaBuscada = GetTareaId(idTarea);
            if (tareaBuscada != null){
                listadoTareas!.Remove(tareaBuscada);
                accesoADato!.GuardarDatosTarea(listadoTareas!); 
            }
            return listadoTareas!;
        }
        public List<Tarea> GetListadoTareas(){
            return listadoTareas!;
        }
        public List<Tarea> GetListadoTareasCompletadas(){
            return listadoTareas!.FindAll(tareas => tareas.Estado == Tarea.Estados.Completada);
        }
    }
}