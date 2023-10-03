using System.Data.SqlClient;
using Dapper;

public static class BD{
    private static string ConnectionString {get; set;} = @"Server=localhost;DataBase=BD_TP9;Trusted_Connection=True;";

    public static Usuario ObtenerUsuario(string Username){
        Usuario user = null;
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "SELECT * FROM Usuario WHERE username = @usuario";
            user = db.QueryFirstOrDefault<Usuario>(sql, new {usuario = Username});                                                              
        }
        return user;
    }

    public static void CrearUsuario(string Username, string Contrasena, string Nombre, string Apellido, string Email, string preguntaSeguridad){
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "INSERT INTO Usuario(username, contrasena, nombre, apellido, email, preguntaSeguridad) VALUES (@Usuario, @Contra, @Nom, @Ape, @Em, @PS)";
            db.Execute(sql, new {Usuario = Username, Contra = Contrasena, Nom = Nombre, Ape = Apellido, Em = Email, PS = preguntaSeguridad});
        }
    }

    public static List<Usuario> ObtenerUsuarios(){
        List<Usuario> user = null;
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "SELECT * FROM Usuario";
            user = db.Query<Usuario>(sql).ToList();                                                              
        }
        return user;
    }

    public static void CambiarContraseña(string Username, string nuevaContrasena){
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "UPDATE Usuario SET contrasena = @nueva WHERE username = @user";
            db.Execute(sql, new {nueva = nuevaContrasena, user = Username});
        }
    }
}