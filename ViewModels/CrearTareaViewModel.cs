using System.ComponentModel.DataAnnotations;

public class CrearTareaViewModel
{
    public CrearTareaViewModel()
    {
    }

    [Required][MaxLength(50)]
    public string Titulo {get; set;}

    [Required][MaxLength(150)]
    public string Descripcion {get; set;}

    [Required]
    public EstadoTarea Estado {get; set;}        

}