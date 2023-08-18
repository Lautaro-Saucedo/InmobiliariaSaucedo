namespace InmobiliariaSaucedo.Models;

using System.Data;
using MySql.Data.MySqlClient;

public class RepositorioPropietario{
    protected readonly string? connectionString;

    public RepositorioPropietario(IConfiguration config){
        connectionString = config.GetConnectionString("mysql");
    }

    public List<Propietario> ObtenerTodos(){
        List<Propietario> res = new List<Propietario>();
        using(MySqlConnection conn = new MySqlConnection(connectionString)){
            var sql = "SELECT Id,Dni,Nombre,Apellido,Telefono,Email FROM propietarios";
            using(MySqlCommand cmd = new MySqlCommand(sql,conn)){
                conn.Open();
                using(MySqlDataReader reader = cmd.ExecuteReader()){
                    while(reader.Read()){
                        res.Add(new Propietario{
                            Id = reader.GetInt32("Id"),
                            Dni = reader.GetString("Dni"),
                            Nombre = reader.GetString("Nombre"),
                            Apellido = reader.GetString("Apellido"),
                            Telefono = reader.GetString("Telefono"),
                            Email = reader.GetString("Email"),
                        });
                    }
                }
            }
        }
        return res;
    }

    public Propietario Buscar(int id){
        Propietario res=new Propietario();
        using(MySqlConnection conn = new MySqlConnection(connectionString)){
            var sql = $"SELECT Id,Dni,Nombre,Apellido,Telefono,Email FROM propietarios WHERE id={id}";
            using(MySqlCommand cmd = new MySqlCommand(sql,conn)){
                conn.Open();
                using(MySqlDataReader reader = cmd.ExecuteReader()){
                    while(reader.Read()){
                        res =new Propietario{
                            Id = reader.GetInt32("Id"),
                            Dni = reader.GetString("Dni"),
                            Nombre = reader.GetString("Nombre"),
                            Apellido = reader.GetString("Apellido"),
                            Telefono = reader.GetString("Telefono"),
                            Email = reader.GetString("Email"),
                        };
                    }
                }
            }
        }
        return res;
    }

    public int Crear(Propietario i){
        int res = -1;
        using(MySqlConnection conn = new MySqlConnection(connectionString)){
            var sql = @"INSERT INTO propietarios 
                (Dni,Nombre,Apellido,Telefono,Email)
                VALUES (@Dni,@Nombre,@Apellido,@Telefono,@Email);
                LAST_INSERT_ID();";
            using(MySqlCommand cmd = new MySqlCommand(sql,conn)){
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Dni",i.Dni);
                cmd.Parameters.AddWithValue("@Nombre",i.Nombre);
                cmd.Parameters.AddWithValue("@Apellido",i.Apellido);
                cmd.Parameters.AddWithValue("@Telefono",i.Telefono);
                cmd.Parameters.AddWithValue("@Email",i.Email);
                conn.Open();
                res = Convert.ToInt32(cmd.ExecuteScalar());
                i.Id = res;
                conn.Close();
            }
        }
        return res;
    }

    public int Actualizar(Propietario i){
        using(MySqlConnection conn = new MySqlConnection(connectionString)){
            var sql = @"UPDATE propietarios SET
                Nombre = @Nombre, Apellido = @Apellido, Dni = @Dni,
                Telefono = @Telefono, Email = @Email 
                Where Id=@Id;";
            using(MySqlCommand cmd = new MySqlCommand(sql,conn)){
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Dni",i.Dni);
                cmd.Parameters.AddWithValue("@Nombre",i.Nombre);
                cmd.Parameters.AddWithValue("@Apellido",i.Apellido);
                cmd.Parameters.AddWithValue("@Telefono",i.Telefono);
                cmd.Parameters.AddWithValue("@Email",i.Email);
                cmd.Parameters.AddWithValue("@Id",i.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        return i.Id;
    }

    public void Borrar(int id){
        using(MySqlConnection conn = new MySqlConnection(connectionString)){
            var sql = @"DELETE FROM propietarios WHERE Id=@Id";
            using(MySqlCommand cmd = new MySqlCommand(sql,conn)){
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id",id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }    
    
}