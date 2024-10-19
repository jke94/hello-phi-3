namespace hello_phi_3.consoleapp
{
    #region using
    
    using Microsoft.Extensions.Hosting;
    using CommandLine;
    using hello_phi_3;
    using System.Collections;

    #endregion

    public class Program
    {
        public IHost? HostBuilder { get; set; }

        #region Public methods

        public static void Main(string[] args)
        {
            // Parser.Default.ParseArguments<CommandLineOptions>(args)
            //     .WithParsed(Run)
            //     .WithNotParsed(HandleParseError);

            //     HostBuilder = Host.CreateDefaultBuilder(args)
            //     .ConfigureServices(services =>
            //     {
            //         services.AddTransient<Driver>();
            //     })
            //     .Build();                
        }

        #endregion

        #region Private methods

        private static void Run(CommandLineOptions opts)
        {
            if (string.IsNullOrEmpty(opts.ModelPath))
            {
                throw new Exception("Model path must be specified.");
            }

            Console.WriteLine("-------------");
            Console.WriteLine("Hello, Phi! To finalize program please enter '[EXIT]' string.");
            Console.WriteLine("-------------");

            Console.WriteLine("Model path: " + opts.ModelPath);

            if (!Enum.TryParse(opts.Mode, out HelloPhi3Mode optionMode))
            {
                Console.WriteLine("Error in mode. Please, enter a valid option.");
                return;
            }

            Console.WriteLine($"User input: {optionMode}");
            Console.WriteLine();

            string? prompt;
            bool running = true;
            int numPromptsCount = 1;

            do
            {
                Console.WriteLine($"{numPromptsCount} - Please, enter a prompt:");
                numPromptsCount++;

                prompt = Console.ReadLine();

                if (string.IsNullOrEmpty(prompt))
                {
                    Console.WriteLine("Please, enter a valid option: ");
                }
                else if (prompt.Equals("[EXIT]"))
                {
                    running = false;
                }
                else
                {
                    IHelloPhi3Service helloPhi3 = new HelloPhi3Service();
                    helloPhi3.Run(opts.ModelPath, prompt, optionMode);
                }
            }
            while (running);

            Console.WriteLine("Bye from Phi-3 demo!");
        }

        private static void HandleParseError(IEnumerable errs)
        {
            Console.WriteLine("Command Line parameters provided were not valid!");
        }

        #endregion
    }
}
