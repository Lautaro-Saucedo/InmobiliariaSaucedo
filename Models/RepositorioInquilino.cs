namespace InmobiliariaSaucedo.Models;
using MySql.Data.MySqlClient;

public class RepositorioInquilino{
    protected readonly string? connectionString;

    public RepositorioInquilino(IConfiguration config){
        connectionString = config.GetConnectionString("mysql");
    }

    public List<Inquilino> ObtenerTodos(){
        List<Inquilino> res = new List<Inquilino>();
        using(MySqlConnection conn = new MySqlConnection(connectionString)){
            var sql = "SELECT Id,Dni,Nombre,Apellido FROM Inquilinos";
            using(MySqlCommand cmd = new MySqlCommand(sql,conn)){
                conn.Open();
                using(MySqlDataReader reader = cmd.ExecuteReader()){
                    while(reader.Read()){
                        res.Add(new Inquilino{
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