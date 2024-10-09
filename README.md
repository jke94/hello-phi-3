# hello-phi-3
Proof of concept to use Phi-3 model in .NET ecosystem.

## A. Initializing setup to run the proof of concept.

Note: Windows process.

### 1. Create python virtual environment.

```
python -m venv venv
```
### 2. Activate virtual environment.

```
.\venv\Scripts\activate
```
### 3. Install **huggingface-hub[cli]**.

```
pip install huggingface-hub[cli]
```
### 4. HuggingFace downloading process.

#### 4.1. Download model **microsoft/Phi-3-mini-4k-instruct-onnx**

1. Use case to be used in CPU environments.

```
huggingface-cli download microsoft/Phi-3-mini-4k-instruct-onnx --include cpu_and_mobile/cpu-int4-rtn-block-32-acc-level-4/* --local-dir models
```
2. Use case to be used in GPU environments.

```
huggingface-cli download microsoft/Phi-3-mini-4k-instruct-onnx --include cuda/cuda-int4-rtn-block-32/* --local-dir models
```
3. Use case to be used in DirectML environment.

```
huggingface-cli download microsoft/Phi-3-mini-4k-instruct-onnx --include directml/* --local-dir models
```
### 5. Build solution.

1. Use case to be used in CPU environments.

```
dotnet build .\hello-phi-3.sln -c Release
```
2. Use case to be used in GPU environments.

```
dotnet build .\hello-phi-3.sln -c Release_Cuda
```
3. Use case to be used with DirectML environment.

```
dotnet build .\hello-phi-3.sln -c Release_DirectML
```

### 6. Run example:

```
.\hello-phi-3.consoleapp\bin\Release\net8.0\hello-phi-3.consoleapp.exe -m .\models\cpu_and_mobile\cpu-int4-rtn-block-32-acc-level-4 -t StreamingOutput
```

```
.\hello-phi-3.consoleapp\bin\Release_Cuda\net8.0\hello-phi-3.consoleapp.exe -m .\models\cuda\cuda-int4-rtn-block-32 -t StreamingOutput
```

# B. Useful links

- https://github.com/microsoft/onnxruntime-genai/tree/main/examples/csharp/HelloPhi

- [Phi-3CookBook: Phi-3 Prompt Template](https://github.com/microsoft/Phi-3CookBook/blob/main/md/02.QuickStart/Huggingface_QuickStart.md)

- [onnxruntime with Phi-3: Configuration reference](https://onnxruntime.ai/docs/genai/reference/config.html)

- [Cómo Usar Phi-3 con OLlama y C# en tu Entorno Local](https://restofmycloud.com/blog/como-usar-phi-3-con-ollama-y-c-en-tu-entorno-local)

- [Guest Blog: Bring your AI Copilots to the edge with Phi-3 and Semantic Kernel](https://devblogs.microsoft.com/semantic-kernel/guest-blog-bring-your-ai-copilots-to-the-edge-with-phi-3-and-semantic-kernel/)

- [Bring your AI Copilots to the edge with Phi-3 and Semantic Kernel](https://arafattehsin.com/ai-copilot-offline-phi3-semantic-kernel/)