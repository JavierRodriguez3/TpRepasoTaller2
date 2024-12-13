public interface ITareaRepository
{
    void CrearTarea(Tarea tarea);
    Tarea ObtenerTarea(int id);
    void ModificarTarea(int id, Tarea tarea);
    void EliminarTarea(int id);
    List<Tarea> obtenerTareas();
    List<Tarea> ObtenerTareasSegunEstado(EstadoTarea estado);
}