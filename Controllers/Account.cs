using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP9.Models;

public class Account : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Logueado(string Username, string Contrasena)
    {
        Usuario User = BD.ObtenerUsuario(Username);
        ViewBag.Usuario = User;
        if(BD.ObtenerUsuario(Username) == null || User.GetContrasena() != Contrasena){
            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View("Login");
        }
        return View();
    }

    public IActionResult Registro(){
        return View();
    }

    public IActionResult CrearUsuario(string Nombre, string Apellido, string Username, string Email, string Contrasena, string preguntaSeguridad){
        BD.CrearUsuario(Username, Contrasena, Nombre, Apellido, Email, preguntaSeguridad);
        return RedirectToAction("Login");
    }

    public IActionResult CambioContraseña(){
        return View();
    }

    public IActionResult CambiarContraseña(string Username, string nuevaContrasena){
        BD.CambiarContraseña(Username, nuevaContrasena);
        return View("Login");
    }
}