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

        public int Id { get => id; set => id = value; }
        public string? Titulo { get => titulo; set => titulo = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public Estados Estado { get => estado; set => estado = value; }

        public Tarea(){
            this.Estado = Estados.Pendiente;
        }
        public Tarea(int idTarea, string? tituloTarea, string? descripcionTarea){
            this.Id = idTarea;
            this.Titulo = tituloTarea;
            this.Descripcion = descripcionTarea;
            this.Estado = Estados.Pendiente;
        }
        public int GetIdTarea(){
            return this.Id;
        }
        public bool ActualizarEstado(int estadoTarea){
            if (estadoTarea == 1){
                this.Estado = Estados.enProgreso;
                return true;
            }else if (estadoTarea == 2){
                this.Estado = Estados.Completada;
                return true;
            }
            return false;
        }
    }
}