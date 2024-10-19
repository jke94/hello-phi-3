namespace hello_phi_3.consoleapp
{
    #region using
    
    using Microsoft.Extensions.Hosting;
    using hello_phi_3;
    using System.Collections;
    using Microsoft.Extensions.DependencyInjection;
    using CommandLine;

    #endregion

    public class Program
    {
        #region Public methods

        public static async Task<int> Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddTransient<IMainService, MainService>();
            }
            ).Build();

            var myService = host.Services.GetRequiredService<MainService>();
            
            return await myService.RunAsync(args);
        }

        #endregion
    }
}
