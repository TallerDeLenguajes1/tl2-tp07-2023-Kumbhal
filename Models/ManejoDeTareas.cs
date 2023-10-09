using AccesoADato;
using Tareas;

namespace ManejoTarea{
    public class ManejoTareas{
        private AccesoADatos? AccesoADato;
        private List<Tarea>? ListadoTareas;
        public ManejoTareas(AccesoADatos accesoADatos){
            this.AccesoADato = accesoADatos;
            ListadoTareas = accesoADatos.CargarDatosTarea();
        }
        public void CargarTareas(){
            ListadoTareas = AccesoADato?.CargarDatosTarea();
        }
        public void GuardarTareas(){
            AccesoADato?.GuardarDatosTarea(ListadoTareas!);
        }
        public Tarea PostTarea(int idTarea, string? tituloTarea, string? descripcionTarea){
            Tarea tareaCreada = new Tarea(idTarea, tituloTarea, descripcionTarea);
            ListadoTareas!.Add(tareaCreada);
            AccesoADato!.GuardarDatosTarea(ListadoTareas);
            return tareaCreada;
        }
        public Tarea GetTareaId(int idTarea){
            Tarea tareaBuscada = ListadoTareas!.FirstOrDefault(tarea => tarea.GetIdTarea() == idTarea)!;
            return tareaBuscada;
        }
        public bool ActualizarTarea(int estadoTarea, int idTarea){
            Tarea tareaBuscada = GetTareaId(idTarea);
            if (tareaBuscada != null){
                if (tareaBuscada.ActualizarEstado(estadoTarea)){
                    AccesoADato!.GuardarDatosTarea(ListadoTareas!);
                    return true;
                }
            }
            return false;
        }
        public List<Tarea> EliminarTarea(int idTarea){
            Tarea tareaBuscada = GetTareaId(idTarea);
            if (tareaBuscada != null){
                ListadoTareas!.Remove(tareaBuscada);
                AccesoADato!.GuardarDatosTarea(ListadoTareas!); 
            }
            return ListadoTareas!;
        }
        public List<Tarea>? MostrarTareas(){
            return ListadoTareas;
        }
        public List<Tarea> GetListadoTareasCompletadas(){
            return ListadoTareas.FindAll(tareas => tareas.Estado == Tarea.Estados.Completada);
        }
    }
}