using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioProyectos _repositorioProyectos;
        private readonly IServicioEmail _servicioEmail;

        public HomeController(
        IRepositorioProyectos repositorioProyectos,
        IServicioEmail servicioEmail
        )
        {
            _repositorioProyectos = repositorioProyectos;
            _servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            var proyectos = _repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }        

        public IActionResult Proyectos()
        {
            var proyectoList = _repositorioProyectos.ObtenerProyectos();
            return View(proyectoList);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoDTO contactoInfo)
        {
            await _servicioEmail.Enviar(contactoInfo);
            return RedirectToAction("Gracias"); ;
        }

        public IActionResult Gracias() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}