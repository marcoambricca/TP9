public class Usuario{
    public string username {get; set;}
    private string contrasena {get; set;}
    public string nombre {get; set;}
    public string apellido {get; set;}
    public string email {get; set;}

    public Usuario(){}
    public Usuario(string user, string pass, string nom, string ap, string mail){
        username = user;
        contrasena = pass;
        nombre = nom;
        apellido = ap;
        email = mail;
    }
    public string GetContrasena(){
        return contrasena;
    }
}