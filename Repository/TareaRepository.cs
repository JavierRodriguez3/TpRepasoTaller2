using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.Data.Sqlite;

public class TareaRepository : ITareaRepository
{
    private string _cadenaDeConexion;
    public TareaRepository(string cadenaDeConexion)
    {
        _cadenaDeConexion = cadenaDeConexion;
    }

    public void CrearTarea(Tarea tarea)
    {
        string query = @"INSERT INTO Tarea (Titulo, Descripcion, Estado) VALUES (@titulo, @descripcion, @estado)"; //consulta

        using (SqliteConnection connecion = new SqliteConnection(_cadenaDeConexion))
        {
            connecion.Open();
            SqliteCommand command = new SqliteCommand(query, connecion);

            command.Parameters.AddWithValue("@titulo", tarea.Titulo);
            command.Parameters.AddWithValue("@descripcion", tarea.Descripcion);
            command.Parameters.AddWithValue("estado", (int)tarea.Estado);
            command.ExecuteNonQuery();
        }
    }



    public Tarea ObtenerTarea(int id)
    {
        Tarea tarea = null; //Tiro null si no encuentro nada

        string query = @"SELECT * FROM Tarea WHERE TareaId = @id";

        using (SqliteConnection connection = new SqliteConnection(_cadenaDeConexion))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue(@"id", id);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    tarea = new Tarea();
                    tarea.TareaId = Convert.ToInt32(reader["TareaId"]);
                    tarea.Titulo = reader["Titulo"].ToString();
                    tarea.Descripcion = reader["Descripcion"].ToString();
                    tarea.Estado = (EstadoTarea)Convert.ToInt32(reader["Estado"]);
                }
            }
            connection.Close();
        }
        return tarea;
    }

    public void ModificarTarea(int id, Tarea tarea)
    {
        string query = @"UPDATE Tarea SET Titulo = @titulo, Descripcion = @descripcion, Estado = @estado WHERE TareaId = @id";

        using (SqliteConnection connection = new SqliteConnection(_cadenaDeConexion))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@id", tarea.TareaId);
            command.Parameters.AddWithValue("@titulo", tarea.Titulo);
            command.Parameters.AddWithValue("@descripcion", tarea.Descripcion);
            command.Parameters.AddWithValue("estado", (int)tarea.Estado);
            connection.Close();
        }
    }

    public void EliminarTarea(int id)
    {
        string query = @"DELETE FROM Tarea WHERE TareaId = @id";

        using (SqliteConnection connection = new SqliteConnection(_cadenaDeConexion))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public List<Tarea> obtenerTareas()
    {
        List<Tarea> tareas = new List<Tarea>();

        string query = "SELECT * FROM Tarea";

        using (SqliteConnection connection = new SqliteConnection(_cadenaDeConexion))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(query, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    Tarea nuevaTarea = new Tarea();
                    nuevaTarea.TareaId = Convert.ToInt32(reader["TareaId"]);
                    nuevaTarea.Titulo = reader["Titulo"].ToString();
                    nuevaTarea.Descripcion = reader["Descripcion"].ToString();
                    nuevaTarea.Estado = (EstadoTarea)Convert.ToInt32(reader["Estado"]);
                    tareas.Add(nuevaTarea);
                }
            }
            connection.Close();
        }
        return tareas;
    }

    public List<Tarea> ObtenerTareasSegunEstado(EstadoTarea estado)
{
    List<Tarea> tareas = new List<Tarea>();

    string query = "SELECT * FROM Tarea WHERE Estado = @estado";

    using (SqliteConnection connection = new SqliteConnection(_cadenaDeConexion))
    {
        connection.Open();
        using (SqliteCommand command = new SqliteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@estado", (int)estado); // Filtrar solo las tareas completadas

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Tarea nuevaTarea = new Tarea
                    {
                        TareaId = Convert.ToInt32(reader["TareaId"]),
                        Titulo = reader["Titulo"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Estado = (EstadoTarea)Convert.ToInt32(reader["Estado"])
                    };

                    tareas.Add(nuevaTarea); // Agregar la tarea completada a la lista
                }
            }
        }
    }

    return tareas;
}

}