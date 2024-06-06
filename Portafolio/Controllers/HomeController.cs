using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var proyectos = ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }

        public List<ProyectoDTO> ObtenerProyectos()
        {
            return new List<ProyectoDTO> {
                new ProyectoDTO
                {
                    Titulo = "Amazon",
                    Descripcion = "E-commerce realizado en ASP .Net Core",
                    Link = "https://www.amazon.com/-/es/",
                    ImagenURL = "/imagenes/Amazon.png"
                },
                new ProyectoDTO
                {
                    Titulo = "Crunchyroll",
                    Descripcion = "Página para ver Anime en React",
                    Link = "https://www.crunchyroll.com/es/",
                    ImagenURL = "/imagenes/Crunchyroll.png"
                },
                new ProyectoDTO
                {
                    Titulo = "Reddit",
                    Descripcion = "Red social para compartir en comunidades",
                    Link = "https://www.reddit.com",
                    ImagenURL = "/imagenes/Reddit.jpg"
                },
                new ProyectoDTO
                {
                    Titulo = "Steam",
                    Descripcion = "Tienda en linea para comprar video juegos",
                    Link = "https://store.steampowered.com/?l=spanish",
                    ImagenURL = "/imagenes/Steam.jpg"
                }
            };
        }

        public IActionResult Privacy()
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