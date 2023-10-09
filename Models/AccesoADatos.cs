using Tareas;
using System.Text.Json;

namespace AccesoADato{
    public class AccesoADatos{
        public AccesoADatos(){}
        public List<Tarea> CargarDatosTarea(string? rutaArchivo){
            if(File.Exists(rutaArchivo)){
                string? datosCargados = File.ReadAllText(rutaArchivo);
                if (!string.IsNullOrEmpty(datosCargados)){
                    return JsonSerializer.Deserialize<List<Tarea>>(datosCargados)!;
                }
            }
            return new List<Tarea>();
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