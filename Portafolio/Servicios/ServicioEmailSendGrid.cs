using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Servicios
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoDTO contactoDTO);
    }
    public class ServicioEmailSendGrid : IServicioEmail
    {
        private readonly IConfiguration _configuration;
        public ServicioEmailSendGrid(IConfiguration configuration)
        {

            _configuration = configuration;

        }

        public async Task Enviar(ContactoDTO contactoDTO)
        {
            var apiKei = _configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = _configuration.GetValue<string>("SENDGRID_FROM");
            var nombre = _configuration.GetValue<string>("SENDGRID_NOMBRE");

            var cliente = new SendGridClient(apiKei);
            var from = new EmailAddress(email, nombre);
            var subject = $"El cliente {contactoDTO.Email} quiere contactarte";
            var to = new EmailAddress(email, nombre);
            var mensajeTextoPlano = contactoDTO.Mensaje;
            var contenidoHTML = $@"
            De: {contactoDTO.Nombre}
            Email: {contactoDTO.Email}
            Mensaje: {contactoDTO.Mensaje}
            ";
            var singleEmail = MailHelper.CreateSingleEmail(from,to,subject,mensajeTextoPlano,contenidoHTML);
            var respuesta = await cliente.SendEmailAsync(singleEmail);
        }
    }
}
