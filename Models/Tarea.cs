public enum EstadoTarea
{
    Pendiente = 0,
    EnProgreso = 1,
    Completada = 2
}

public class Tarea
{
    private int tareaId;
    private string titulo;
    private string descripcion;
    private EstadoTarea estado;

    
    public int TareaId { get => tareaId; set => tareaId = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public EstadoTarea Estado { get => estado; set => estado = value; }
    public Tarea(int tareaId, string titulo, string descripcion, EstadoTarea estado)
    {
        this.tareaId = tareaId;
        this.titulo = titulo;
        this.descripcion = descripcion;
        this.estado = estado;
    }

    public Tarea(){}
    
}