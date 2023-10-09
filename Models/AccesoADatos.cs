using Tareas;
using System.Text.Json;

namespace AccesoADato{
    public class AccesoADatos{
        public AccesoADatos(){}
        public List<Tarea> CargarDatosTarea(){
            string? rutaArchivo = "Tareas.json";
            List<Tarea>? nuevaListaTarea = null;
            if(File.Exists(rutaArchivo)){
                string JsonTarea = File.ReadAllText(rutaArchivo);
                List<Tarea>? ListAux = JsonSerializer.Deserialize<List<Tarea>>(JsonTarea);
                nuevaListaTarea = ListAux;
            }
            return nuevaListaTarea;
        }

        public void GuardarDatosTarea(List<Tarea> listadoTareas){
            string? rutaArchivo = "Tareas.json";
            if (listadoTareas != null){
                string? datosCargados = JsonSerializer.Serialize(listadoTareas, new JsonSerializerOptions{WriteIndented = true});
                File.WriteAllText(rutaArchivo!, datosCargados);
            }else{
                Console.WriteLine("Se produjo un error al guardar los datos.");
            }
        }
    }
}