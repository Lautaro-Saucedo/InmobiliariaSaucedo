namespace InmobiliariaSaucedo.Models;
using MySql.Data.MySqlClient;

public class RepositorioPropietario{
    protected readonly string? connectionString;

    public RepositorioPropietario(IConfiguration config){
        connectionString = config.GetConnectionString("mysql");
    }

    public List<Propietario> ObtenerTodos(){
        List<Propietario> res = new List<Propietario>();
        using(MySqlConnection conn = new MySqlConnection(connectionString)){
            var sql = "SELECT Id,Dni,Nombre,Apellido FROM Propietarios";
            using(MySqlCommand cmd = new MySqlCommand(sql,conn)){
                conn.Open();
                using(MySqlDataReader reader = cmd.ExecuteReader()){
                    while(reader.Read()){
                        res.Add(new Propietario{
                            Id = reader.GetInt32("Id"),
                            Dni = reader.GetInt64("Dni"),
                            Nombre = reader.GetString("Nombre"),
                            Apellido = reader.GetString("Apellido"),
                        });
                    }
                }
            }
        }
        return res;
    }

    
}