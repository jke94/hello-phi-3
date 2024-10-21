namespace hello_phi_3.consoleapp
{
    #region using

    using CommandLine;

    #endregion

    public class CommandLineOptions
    {
        [Option('v', "verbose", Required = false, HelpText = "Enable verbose output.")]
        public bool Verbose { get; set; }

        [Option('t', "mode", Required = true, HelpText = "Complete output (CompleteOutput) or streaming output (StreamingOutput).")]
        public string? Mode { get; set; }

        [Option('m', "model", Required = true, HelpText = "Model path.")]
        public string? ModelPath { get; set; }
    }
}
