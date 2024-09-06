using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransferMarket.Models;
using TransferMarket.Data;
using TransferMarket.ViewModels;
using System.Security.Claims; 
using Microsoft.AspNetCore.Authentication; 
using Microsoft.AspNetCore.Authentication.Cookies;
using BCrypt.Net;

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

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(modelo.Contraseña);

            var administrador = new Administrador
            {
                Nombre = modelo.Nombre,
                Usuario = modelo.Usuario,
                Email = modelo.Email,
                Contraseña = hashedPassword
            };

            await _context.Administradores.AddAsync(administrador);
            await _context.SaveChangesAsync();

            if (administrador.Id != 0)
            {
                return RedirectToAction("Login", "Acceso");
            }

            ViewData["Mensaje"] = "Error Fatal, No se pudo crear el Usuario Administrador";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM modelo)
        {
            // Buscar el administrador por Email o Usuario
            var administrador = await _context.Administradores
                .Where(a => a.Email == modelo.Login || a.Usuario == modelo.Login)
                .FirstOrDefaultAsync();

            if (administrador == null)
            {
                ViewData["Mensaje"] = "El Usuario no existe, puede que el Correo o el Nombre de Usuario sean incorrectos.";
                return View();
            }

            // Verificar la contraseña
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(modelo.Password, administrador.Contraseña);

            if (!isPasswordValid)
            {
                ViewData["Mensaje"] = "La contraseña es incorrecta.";
                return View();
            }

            // Crear los claims y la identidad del usuario
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, administrador.Nombre),
                new Claim(ClaimTypes.Email, administrador.Email),
                new Claim(ClaimTypes.NameIdentifier, administrador.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var properties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true, // Mantener la sesión activa
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30) // Tiempo de expiración
            };

            // Iniciar sesión del usuario
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
            );

            return RedirectToAction("Index", "Home");
        }
    }
}
