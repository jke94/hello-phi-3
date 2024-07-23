namespace hello_phi_3.consoleapp
{
    #region using

    using hello_phi_3;

    #endregion

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("  -m model_path");
            Console.WriteLine("  -i (optional): Intereactive mode");
                  
            uint i = 0;
            bool intereactive = false;
            string modelPath = string.Empty;

            while (i < args.Length)
            {
                var arg = args[i];
                if (arg == "-i")
                {
                    intereactive = true;
                }
                else if (arg == "-m")
                {
                    if (i + 1 < args.Length)
                    {
                        modelPath = Path.Combine(args[i+1]);
                    }
                }

                i++;
            }

            if (string.IsNullOrEmpty(modelPath))
            {
                throw new Exception("Model path must be specified");
            }

            Console.WriteLine("-------------");
            Console.WriteLine("Hello, Phi!");
            Console.WriteLine("-------------");

            Console.WriteLine("Model path: " + modelPath);
            Console.WriteLine("Intereactive: " + intereactive);

            var option = 2;
            if (intereactive)
            {
                Console.WriteLine("Please enter option number:");
                Console.WriteLine("1. Complete Output");
                Console.WriteLine("2. Streaming Output");
                int.TryParse(Console.ReadLine(), out option);
            }

            var optionMode = option == 1 ? HelloPhi3Mode.CompleteOutput : HelloPhi3Mode.StreamingOutput;
            do
            {
                string prompt = "def is_prime(num):"; // Example prompt
                if (intereactive)
                {
                    Console.WriteLine("Prompt:");
                    prompt = Console.ReadLine();
                }

                if(string.IsNullOrEmpty(prompt))
                {
                    continue;
                }

                if (prompt.Equals("[EXIT]"))
                {
                    break;
                }

                if(!string.IsNullOrEmpty(prompt))
                {
                    HelloPhi3.Run(modelPath, prompt, optionMode);
                }
            } 
            while (intereactive);

            Console.WriteLine("Bye from Phi-3 demo!");
        }
    }
}
