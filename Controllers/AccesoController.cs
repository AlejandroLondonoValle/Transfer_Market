using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TransferMarket.Models;
using TransferMarket.Data;
using TransferMarket.ViewModels;
using System.Security.Claims; //Guarda la informacion del Usuario
using Microsoft.AspNetCore.Authentication; //Permite la autenticacion de usuarios
using Microsoft.AspNetCore.Authentication.Cookies;

namespace TransferMarket.Controllers
{
    public class AccesoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccesoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AdministradorVm modelo)
        {
            if (modelo.Contraseña != modelo.ConfirmarContraseña)
            {
                ViewData["Mensaje"] = "Las Contraseñas no coinciden";
                return View();
            }

            Administrador administrador = new Administrador()
            {
                Nombre = modelo.Nombre,
                Email = modelo.Email,
                Contraseña = modelo.Contraseña
            };

            await _context.Administradores.AddAsync(administrador);
            await _context.SaveChangesAsync();

            if (administrador.Id != 0)
            {
                return RedirectToAction("Login", "Access");
            }
            ViewData["Mensaje"] = "Error Fatal, No se pudo crear el Usuario Administrador";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM modelo)
        {
            Administrador administrador_found = await _context.Administradores
                                .Where(a =>
                                 a.Email == modelo.Email &&
                                 a.Contraseña == modelo.Password).FirstOrDefaultAsync();

            if (administrador_found == null)
            {
                ViewData["Mensaje"] = "El Usuario no existe, puede que el Correo o la Contraseña  sean Incorrectos";
                return View();
            }

            List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, administrador_found.Nombre)
            //Agregar mas claims si es necesario
        };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
            );

            return RedirectToAction("Index", "Home");
        }
    }
}