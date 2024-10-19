namespace hello_phi_3.consoleapp
{
    #region using

    using CommandLine;

    #endregion

    public interface IMainService
    {
        public Task<int> RunAsync(string[] args);
    }

    public class MainService : IMainService
    {
        public async Task<int> RunAsync(string [] args)
        {
            return await Parser.Default.ParseArguments<CommandLineOptions>(args)
            .MapResult(async (CommandLineOptions opts) =>
            {
                try
                {
                    return await Task.Run(() => RunPhi3(opts));
                }
                catch
                {
                    Console.WriteLine("Error!");
                    return -3;
                }
            },
            errs => Task.FromResult(-1));
        }

        private int RunPhi3(CommandLineOptions options)
        {
            // TODO: Implement async operation.

            if (string.IsNullOrEmpty(options.ModelPath))
            {
                throw new Exception("Model path must be specified.");
            }

            Console.WriteLine("-------------");
            Console.WriteLine("Hello, Phi! To finalize program please enter '[EXIT]' string.");
            Console.WriteLine("-------------");

            Console.WriteLine("Model path: " + options.ModelPath);

            if (!Enum.TryParse(options.Mode, out HelloPhi3Mode optionMode))
            {
                Console.WriteLine("Error in mode. Please, enter a valid option.");

                return -1;
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
                    helloPhi3.Run(options.ModelPath, prompt, optionMode);
                }
            }
            while (running);

            Console.WriteLine("Bye from Phi-3 demo!");

            return 0;
        }
    }
}