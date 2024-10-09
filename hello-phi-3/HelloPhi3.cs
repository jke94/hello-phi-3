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
        public static void Run(string modelPath, string userPrompt, HelloPhi3Mode helloPhi3Mode)
        {
            if (string.IsNullOrEmpty(modelPath))
            {
                throw new Exception("Model path must be specified");
            }

            if (string.IsNullOrEmpty(userPrompt))
            {
                return;
            }

            using Model model = new Model(modelPath);

            using Tokenizer tokenizer = new Tokenizer(model);
            using GeneratorParams generatorParams = new GeneratorParams(model);

            var fullPrompt = $"<|user|>{userPrompt}<|end|><|assistant|>";
            var sequences = tokenizer.Encode(fullPrompt);
            generatorParams.SetInputSequences(sequences);

            generatorParams.SetSearchOption("max_length", 300);
            generatorParams.SetSearchOption("past_present_share_buffer", false);

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
