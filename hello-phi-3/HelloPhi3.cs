namespace hello_phi_3
{
    #region using

    using Microsoft.ML.OnnxRuntimeGenAI;

    #endregion

    public enum HelloPhi3Mode
    {
        CompleteOutput = 0,
        StreamingOutput = 1
    }

    public class HelloPhi3
    {
        public static void Run(string modelPath, string prompt, HelloPhi3Mode helloPhi3Mode)
        {
            if (string.IsNullOrEmpty(modelPath))
            {
                throw new Exception("Model path must be specified");
            }

            if (string.IsNullOrEmpty(prompt))
            {
                return;
            }

            using Model model = new Model(modelPath);
            using Tokenizer tokenizer = new Tokenizer(model);

            var sequences = tokenizer.Encode($"<|user|>{prompt}<|end|><|assistant|>");

            using GeneratorParams generatorParams = new GeneratorParams(model);

            generatorParams.SetSearchOption("max_length", 200);
            generatorParams.SetInputSequences(sequences);

            if (helloPhi3Mode == HelloPhi3Mode.CompleteOutput)
            {
                var outputSequences = model.Generate(generatorParams);
                var outputString = tokenizer.Decode(outputSequences[0]);

                Console.WriteLine("Output:");
                Console.WriteLine(outputString);
            }
            else if (helloPhi3Mode == HelloPhi3Mode.StreamingOutput)
            {
                using var tokenizerStream = tokenizer.CreateStream();
                using var generator = new Generator(model, generatorParams);

                while (!generator.IsDone())
                {
                    generator.ComputeLogits();
                    generator.GenerateNextToken();
                    Console.Write(tokenizerStream.Decode(generator.GetSequence(0)[^1]));
                }
                Console.WriteLine();
            }
        }
    }
}
