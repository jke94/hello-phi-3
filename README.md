# hello-phi-3
Proof of concept to use Phi-3 model in .NET ecosystem.

## A. Initializing setup to run the proof of concept.

Windows:

1. Create python virtual environment.

```
python -m venv venv
```
2. Activate virtual environment.

```
.\venv\Scripts\activate
```
3. Install **huggingface-hub[cli]**.

```
pip install huggingface-hub[cli]
```
4. Download the model **microsoft/Phi-3-mini-4k-instruct-onnx** from HuggingFace.

```
huggingface-cli download microsoft/Phi-3-mini-4k-instruct-onnx --include cpu_and_mobile/cpu-int4-rtn-block-32-acc-level-4/* --local-dir models
```
4. Moving models to the correct place.

```
move models\cpu_and_mobile\cpu-int4-rtn-block-32-acc-level-4 models\phi-3
```

5. Build project:

```
dotnet build .\hello-phi-3.consoleapp\hello-phi-3.consoleapp.csproj -c Release
```
6. Run example:

```
.\hello-phi-3.consoleapp\bin\Release\net8.0\hello-phi-3.consoleapp.exe -i -m .\models\phi-3\
```

# B. Link

- https://github.com/microsoft/onnxruntime-genai/tree/main/examples/csharp/HelloPhi