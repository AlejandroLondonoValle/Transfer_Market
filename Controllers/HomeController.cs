using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TransferMarket.Models;
using Microsoft.AspNetCore.Authentication; //Permite la autenticacion de usuarios
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace TransferMarket.Controllers;

[Authorize] //Esta anotacion habilita la accion solo para usuarios autenticados, en este caso inhibe todo dentro de la clase home controller pero se puede ihibir solo un metodo, si asi es necesario
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
        public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> Exit()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login","Acceso");
    }

}