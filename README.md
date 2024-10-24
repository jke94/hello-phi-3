# hello-phi-3
Proof of concept to use [**microsoft/Phi-3-mini-4k-instruct-onnx**](https://huggingface.co/microsoft/Phi-3-mini-4k-instruct-onnx) model in .NET ecosystem with ONNX runtime running in CPU.

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

Use case to be used in CPU environments.

```
huggingface-cli download microsoft/Phi-3-mini-4k-instruct-onnx --include cpu_and_mobile/cpu-int4-rtn-block-32-acc-level-4/* --local-dir models/microsoft/Phi-3-mini-4k-instruct-onnx
```
### 5. Build solution.

Use case to be used with CPU environments.

```
dotnet build .\hello-phi-3.sln -c Release
```
## B. Playing with Phi3 in CPU!

### 1. Run example:

```
dotnet run --project .\hello-phi-3.consoleapp\hello-phi-3.consoleapp.csproj -c Release --model .\models\microsoft\Phi-3-mini-4k-instruct-onnx\cpu_and_mobile\cpu-int4-rtn-block-32-acc-level-4 --mode StreamingOutput
```

### 2. Example output!

```
PS J:\Repositories\hello-phi-3> dotnet run --project .\hello-phi-3.consoleapp\hello-phi-3.consoleapp.csproj -c Release --model .\models\microsoft\Phi-3-mini-4k-instruct-onnx\cpu_and_mobile\cpu-int4-rtn-block-32-acc-level-4 --mode StreamingOutput
-------------
Hello, Phi! To finalize program please enter '[EXIT]' string.
-------------
Model path: .\models\microsoft\Phi-3-mini-4k-instruct-onnx\cpu_and_mobile\cpu-int4-rtn-block-32-acc-level-4
User input: StreamingOutput

1 - Please, enter a prompt:
Tell me something about The Moon.
 The Moon is Earth's only natural satellite and the fifth largest moon in the solar system. It is about 238,855 miles (384,400 kilometers) away from Earth, and it takes approximately 27.3 days for the Moon to complete one orbit around our planet. The Moon's surface is covered in craters, mountains, and valleys, with the largest crater being the South Politken basin, which is about 1,300 miles (2,090 kilometers) in diameter.

The Moon's surface is also marked by the presence of dark, flat areas called "maria" (Latin for "seas"), which were once believed to be bodies of water. However, these maria are actually vast basaltic plains formed by ancient volcanic eruptions. The Moon's surface is extremely dry, with no atmosphere to speak of, and it experiences extreme temperature variations, ranging from -173°C (-280°F) at the darkest regions to 127°C (260°F) at the brightest regions.

The Moon's gravity is about 1/6th that of Earth's, which means that objects on the Moon weigh only 16.5% of their
2 - Please, enter a prompt:
Dime algo sobre el planeta Marte.
 El planeta Marte es el cuarto planeta del sistema solar y un cuerpo celeste de gran interés para los científicos y los exploradores espaciales. Aquí hay algunos datos fascinantes sobre Marte:

1. Tamaño y distancia: Marte es aproximadamente el 15% más grande que la Tierra y se encuentra a una distancia de 225 millones de kilómetros (140 millones de millas) de la Tierra.

2. Atmósfera: Marte tiene una atmósfera muy delgada, compuesta principalmente de dióxido de carbono (95.3%), con trazas de nitrógeno (2.7%), argón (1.6%) y otros gases. La presión atmosférica es solo el 1% de la de la Tierra.

3. Temperaturas: Las temperaturas en Marte varían ampliamente, desde -125°C (-195°F) en el polo sur durante el invierno hasta 20°C (68°F) en el verano en el hemisferio sur.

4. Campos magnéticos: Marte tiene un campo magnético débil y des
3 - Please, enter a prompt:
[EXIT] 
Bye from Phi-3 demo!
PS J:\Repositories\hello-phi-3> 
```


# B. Useful links

- [Github: Generate() API C# example](https://github.com/microsoft/onnxruntime-genai/tree/main/examples/csharp/HelloPhi)

- [Phi-3CookBook: Phi-3 Prompt Template](https://github.com/microsoft/Phi-3CookBook/blob/main/md/02.QuickStart/Huggingface_QuickStart.md)

- [onnxruntime with Phi-3: Configuration reference](https://onnxruntime.ai/docs/genai/reference/config.html)

- [Cómo Usar Phi-3 con OLlama y C# en tu Entorno Local](https://restofmycloud.com/blog/como-usar-phi-3-con-ollama-y-c-en-tu-entorno-local)

- [Guest Blog: Bring your AI Copilots to the edge with Phi-3 and Semantic Kernel](https://devblogs.microsoft.com/semantic-kernel/guest-blog-bring-your-ai-copilots-to-the-edge-with-phi-3-and-semantic-kernel/)

- [Bring your AI Copilots to the edge with Phi-3 and Semantic Kernel](https://arafattehsin.com/ai-copilot-offline-phi3-semantic-kernel/)