using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.Model;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace GestionSolicitudes.BLL.Servicios
{
    public class APIService : IAPIService
    {
        private static string? _usuario;
        private static string? _clave;
        private static string _baseurl;
        private static string? _token;
        private readonly IConfiguration _configuration;


        public APIService(IConfiguration configuracion)
        {
            _configuration = configuracion;
            _usuario = _configuration.GetSection("ApiSettings:usuario").Value;
            _clave = _configuration.GetSection("ApiSettings:clave").Value;
            _baseurl = _configuration.GetSection("ApiSettings:baseUrl").Value!;
        }

        public async Task Autenticar()
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var credenciales = new CredencialAPI() { usuario  = _usuario!, clave = _clave!};

            //Agregar Newtonsoft.Json - Consumir WEB API desde aSP.NET CORe
            /*var content = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("urlValidar", content);
            var json_respuesta = await response.Content.ReadAsStringAsync();

            var resultado = JsonConverter.DeserializeObject<ResultadoCredencialAPI>(json_respuesta);

            _token = resultado.token;*/
            _token = "apis-token-5330.BLa3uNGI6hj1FptQn112sQ2wWV73Y0Y-";
        }

        public async Task<PersonaAPI> validarDni(string numDocumento)
        {
            PersonaAPI persona = new PersonaAPI();

            await Autenticar();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await cliente.GetAsync($"reniec/dni?numero={numDocumento}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoPersonaAPI>(json_respuesta);
                persona.nombres = resultado!.nombres;
                persona.apellidoPaterno = resultado.apellidoPaterno;
                persona.apellidoMaterno = resultado.apellidoMaterno;
                persona.numeroDocumento = resultado.numeroDocumento;
            }
            return persona;

        }
    }
}
