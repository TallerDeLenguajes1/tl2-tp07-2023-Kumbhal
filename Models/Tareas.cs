namespace Tareas{
    public class Tarea{
        public enum Estados{
            Pendiente = 0,
            enProgreso = 1,
            Completada = 2
        }
        private int id;
        private string? titulo;
        private string? descripcion;
        private Estados estado;
        public int Id {get =>id;}
        public string? Titulo {get => titulo;}
        public string? Descripcion {get => descripcion;}
        public Estados Estado {get => estado;}
        public Tarea(){
            this.estado = Estados.Pendiente;
        }
        public Tarea(int idTarea, string? tituloTarea, string? descripcionTarea){
            this.id = idTarea;
            this.titulo = tituloTarea;
            this.descripcion = descripcionTarea;
            this.estado = Estados.Pendiente;
        }
        public int GetIdTarea(){
            return this.id;
        }
        public bool ActualizarEstado(int estadoTarea){
            if (estadoTarea == 1){
                this.estado = Estados.enProgreso;
                return true;
            }else if (estadoTarea == 2){
                this.estado = Estados.Completada;
                return true;
            }
            return false;
        }
    }
}