namespace hello_phi_3.consoleapp
{
    #region using
    
    using Microsoft.Extensions.Hosting;
    using hello_phi_3;
    using Microsoft.Extensions.DependencyInjection;

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
                services.AddTransient<IHelloPhi3Service, HelloPhi3Service>();
            }
            ).Build();

            var myService = host.Services.GetRequiredService<IMainService>();
            
            return await myService.RunAsync(args);
        }

        #endregion
    }
}
