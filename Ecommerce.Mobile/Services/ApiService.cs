using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Ecommerce.Shared.Entities;

namespace Ecommerce.Mobile.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7039/api/countries";
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiService()
        {
            // Este handler permite saltarse la validación de certificados en entorno de desarrollo
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            _httpClient = new HttpClient(handler);
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            // Usar la configuración basada en la plataforma
            _baseUrl = ConfigService.GetApiBaseUrl();
            Debug.WriteLine($"URL de API configurada: {_baseUrl}");

        }

        // GET - Obtener todos los países
        public async Task<List<Country>> GetCountriesAsync()
        {
            try
            {
                // Imprimir la URL para diagnóstico
                Debug.WriteLine($"Realizando solicitud GET a: {_baseUrl}");

                var response = await _httpClient.GetAsync(_baseUrl);

                // Imprimir el código de respuesta
                Debug.WriteLine($"Código de respuesta: {response.StatusCode}");

                // Si la respuesta no es exitosa, registrar el contenido de error
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"Error en la respuesta: {errorContent}");

                    // Mostrar una alerta o mensaje al usuario
                    await Application.Current.MainPage.DisplayAlert(
                        "Error de API",
                        $"Error al obtener países. Código: {response.StatusCode}",
                        "OK");

                    return new List<Country>();
                }

                var content = await response.Content.ReadAsStringAsync();

                // Imprimir la respuesta completa para diagnóstico
                Debug.WriteLine($"Respuesta recibida: {content}");

                // Intentar deserializar
                try
                {
                    var result = JsonSerializer.Deserialize<List<Country>>(content, _jsonOptions);
                    Debug.WriteLine($"Países deserializados: {result?.Count ?? 0}");
                    return result ?? new List<Country>();
                }
                catch (JsonException jsonEx)
                {
                    Debug.WriteLine($"Error al deserializar JSON: {jsonEx.Message}");
                    await Application.Current.MainPage.DisplayAlert(
                        "Error de Formato",
                        "El formato de la respuesta no coincide con el esperado. Revisa el modelo.",
                        "OK");
                    return new List<Country>();
                }
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"Error HTTP al obtener países: {ex.Message}");

                string errorMessage = "Error de conexión a la API";
                if (ex.Message.Contains("certificate") || ex.Message.Contains("SSL"))
                {
                    errorMessage = "Error de certificado SSL. Verifica la configuración de desarrollo.";
                }
                else if (ex.Message.Contains("connection"))
                {
                    errorMessage = "No se pudo conectar al servidor. Verifica que la API esté en ejecución.";
                }

                await Application.Current.MainPage.DisplayAlert("Error de Conexión", errorMessage, "OK");
                return new List<Country>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error general al obtener países: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    $"Error inesperado: {ex.Message}",
                    "OK");
                return new List<Country>();
            }
        }

        // GET - Obtener un país por ID
        public async Task<Country> GetCountryAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Country>(content, _jsonOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener país: {ex.Message}");
                return null;
            }
        }

        // POST - Crear un nuevo país
        public async Task<bool> AddCountryAsync(Country country)
        {
            try
            {
                var json = JsonSerializer.Serialize(country, _jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_baseUrl, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar país: {ex.Message}");
                return false;
            }
        }

        // PUT - Actualizar un país
        public async Task<bool> UpdateCountryAsync(Country country)
        {
            try
            {
                var json = JsonSerializer.Serialize(country, _jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{_baseUrl}/{country.Id}", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar país: {ex.Message}");
                return false;
            }
        }

        // DELETE - Eliminar un país
        public async Task<bool> DeleteCountryAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar país: {ex.Message}");
                return false;
            }
        }
    }
}