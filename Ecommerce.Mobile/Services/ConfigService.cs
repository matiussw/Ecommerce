namespace Ecommerce.Mobile.Services
{
    public static class ConfigService
    {
        public static string GetApiBaseUrl()
        {
#if ANDROID
            // En Android, localhost se refiere al emulador, no a tu PC
            // 10.0.2.2 es la dirección especial que apunta al host desde el emulador de Android
            return "https://10.0.2.2:7039/api/countries";
#elif IOS
            // En iOS, localhost también se refiere al dispositivo
            // Para iOS (Simulador), usa host.docker.internal o la IP de tu PC
            return "https://localhost:7039/api/countries";
#else
            // Windows u otras plataformas
            return "https://localhost:7039/api/countries";
#endif
        }
    }
}