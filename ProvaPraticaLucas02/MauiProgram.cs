using Microsoft.Extensions.Logging;
using ProvaPraticaLucas02.Services;  // <-- Adicionar using para os Serviços
using ProvaPraticaLucas02.ViewModels; // <-- Adicionar using para as ViewModels
using ProvaPraticaLucas02.Views;     // <-- Adicionar using para as Views

namespace ProvaPraticaLucas02;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // --- ADICIONAR O REGISTRO DE SERVIÇOS ABAIXO ---

        // Registra o serviço de usuário como Singleton (uma única instância para todo o app)
        builder.Services.AddSingleton<UsuarioServices>();

        // Registra a ViewModel e a View como Transient (uma nova instância a cada vez que for chamada)
        builder.Services.AddTransient<UsuarioViewModel>();
        builder.Services.AddTransient<pgLoginUsuarioView>();

        #if DEBUG
        builder.Logging.AddDebug();
        #endif

        return builder.Build();
    }
}
