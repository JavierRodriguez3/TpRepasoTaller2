using System.ComponentModel.DataAnnotations;

public class ModificarTareaViewModel
{
    public ModificarTareaViewModel(Tarea tarea)
    {
        Titulo = tarea.Titulo;
        Descripcion = tarea.Descripcion;
        Estado = tarea.Estado;
    }

    public string Titulo {get; set;}
    public string Descripcion {get; set;}
    public EstadoTarea Estado {get; set;}
}