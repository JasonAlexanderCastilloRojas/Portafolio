using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<ProyectoDTO> ObtenerProyectos();
    }
    public class RepositorioProyectos : IRepositorioProyectos
    {
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
    }
}
