# Quick Start

Please note that the code provided in this page is *purely* for learning purposes and is far from perfect. Remember to null-check all responses!

## Breaking Changes Notice

If you've just updated the package, it is recommended to check the [*changelogs*](https://github.com/Uralstech/UCloud.TextToSpeech/releases) for information on breaking changes.

## Setup

Add an instance of [`TextToSpeechManager`](~/api/Uralstech.UCloud.TextToSpeech.TextToSpeechManager.yml) to your scene, and set it up with your Google Cloud TTS API key.
Check [*this*](https://developers.google.com/workspace/guides/create-credentials) guide on how to create an API key.

There are only two methods in `TextToSpeechManager`:

| Method    | What it does  |
|-----------|---------------|
| [SetApiKey](~/api/Uralstech.UCloud.TextToSpeech.TextToSpeechManager.yml#Uralstech_UCloud_TextToSpeech_TextToSpeechManager_SetApiKey_System_String_)  | Sets the Text To Speech API key |
| Request<sup>[1](~/api/Uralstech.UCloud.TextToSpeech.TextToSpeechManager.yml#Uralstech_UCloud_TextToSpeech_TextToSpeechManager_Request__1_Uralstech_UCloud_TextToSpeech_ITextToSpeechGetRequest_) [2](~/api/Uralstech.UCloud.TextToSpeech.TextToSpeechManager.yml#Uralstech_UCloud_TextToSpeech_TextToSpeechManager_Request__1_Uralstech_UCloud_TextToSpeech_ITextToSpeechPostRequest_)</sup> | Computes a request on the TTS API |

In this page, the fields, properties and methods of each type will not be explained. Every type has been fully documented in code,
so please check the code docstrings or [reference documentation](~/api/Uralstech.UCloud.TextToSpeech.yml) to learn more about each type.

## Beta API

`TextToSpeechManager` supports both the v1 and v1beta TTS API versions. To use the Beta API, you can set the `useBetaApi` boolean parameter in the request object's constructor.

## Synthesis

This is a simple script which synthesizes some text:

```csharp
using Uralstech.UCloud.TextToSpeech;
using Uralstech.UCloud.TextToSpeech.Synthesis;

private AudioSource _audioSource;

protected void Start()
{
    if (!TryGetComponent(out _audioSource))
        _audioSource = gameObject.AddComponent<AudioSource>();
        
    Speak("Hello, World!");
}

private async void Speak(string text)
{
    const TextToSpeechSynthesisAudioEncoding encoding = TextToSpeechSynthesisAudioEncoding.WavLinear16;

    Debug.Log("Sending TTS request.");
    TextToSpeechSynthesisResponse response = await TextToSpeechManager.Instance.Request<TextToSpeechSynthesisResponse>(new TextToSpeechSynthesisRequest()
    {
        Input = new TextToSpeechSynthesisInput(text),
        Voice = new TextToSpeechSynthesisVoiceSelection("en-US"),
        AudioConfiguration = new TextToSpeechSynthesisAudioConfiguration(encoding)
    });

    Debug.Log("TTS response received, playing audio.");
    AudioClip clip = await response.ToAudioClip(encoding);

    _audioSource.PlayOneShot(clip);
}
```

Here, we just create a [`TextToSpeechSynthesisRequest`](~/api/Uralstech.UCloud.TextToSpeech.Synthesis.TextToSpeechSynthesisRequest.yml), pass it to
`TextToSpeechManager`, await the result and convert it to an `AudioClip`. That's all!

Now, let's go over the parameters of `TextToSpeechSynthesisRequest`:
- [`TextToSpeechSynthesisInput`](~/api/Uralstech.UCloud.TextToSpeech.Synthesis.TextToSpeechSynthesisInput.yml)
    - > Contains text input to be synthesized.
    - It has two fields, `Text` and `Ssml`. One of them **must** be provided. See [*SSML*](https://cloud.google.com/text-to-speech/docs/ssml) for more details.
    - The [constructor](~/api/Uralstech.UCloud.TextToSpeech.Synthesis.TextToSpeechSynthesisInput.yml#Uralstech_UCloud_TextToSpeech_Synthesis_TextToSpeechSynthesisInput__ctor_System_String_System_Boolean_)
    has a boolean, `isSsml`, for setting the `Text` or `Ssml` field. It is `false` by default.

- [`TextToSpeechSynthesisVoiceSelection`](~/api/Uralstech.UCloud.TextToSpeech.Synthesis.TextToSpeechSynthesisVoiceSelection.yml)
    - > Description of which voice to use for a synthesis request.
    - It has fields for all the parameters needed for the desired voice, like `Gender`, `Name`, `CustomVoiceParameters`, etc., but the main required field is
    `LanguageCode`.
    - For example, you can create a request that uses the [*Journey*](https://cloud.google.com/text-to-speech/docs/voice-types#journey_voices) voice with the following `TextToSpeechSynthesisVoiceSelection`:
        ```csharp
        new TextToSpeechSynthesisVoiceSelection("en-US")
        {
            Name = "en-US-Journey-F"
        },
        ```

- [`TextToSpeechSynthesisAudioConfiguration`](~/api/Uralstech.UCloud.TextToSpeech.Synthesis.TextToSpeechSynthesisAudioConfiguration.yml)
    - > Description of audio data to be synthesized.
    - Contains fields for configuring the response audio from the TTS API, mainly `Encoding`. Not all encodings are supported by the `ToAudioClip` method.
    Unsupported encodings will have to be converted manually. These are the supported encodings:
        * `WavLinear16`
        * `Mp3`
        * `Mp3_64Kbps` (Requires Beta API)
        
The response from the synthesis request, [`TextToSpeechSynthesisResponse`](~/api/Uralstech.UCloud.TextToSpeech.Synthesis.TextToSpeechSynthesisResponse.yml),
only contains the raw audio data, as a base64 encoded string. There are some other fields for the Beta API, but you can check the reference docs for that.

## Listing Voices

You can also request a list of available voices through the API:

```csharp
using Uralstech.UCloud.TextToSpeech;
using Uralstech.UCloud.TextToSpeech.Voices;

private async void ListAllVoices()
{
    Debug.Log("Getting all voices for en-US.");
    TextToSpeechVoiceListResponse voices = await TextToSpeechManager.Instance.Request<TextToSpeechVoiceListResponse>(
        new TextToSpeechVoiceListRequest("en-US"));

    Debug.Log($"Got the voices:\n{Newtonsoft.Json.JsonConvert.SerializeObject(voices.Voices)}");
}
```

It's just one line of code! You can also list ***all*** voices, for ***every*** language, by using the empty constructor
for [`TextToSpeechVoiceListRequest`](~/api/Uralstech.UCloud.TextToSpeech.Voices.TextToSpeechVoiceListRequest.yml). To
filter list of voices that have been returned by the API in [`TextToSpeechVoiceListResponse`](~/api/Uralstech.UCloud.TextToSpeech.Voices.TextToSpeechVoiceListResponse.yml),
check out the many extension methods that the plugin provides in [`IEnumerableExtensions`](~/api/Uralstech.UCloud.TextToSpeech.Voices.IEnumerableExtensions.yml)!

## Operation Endpoints

To use the operation endpoint methods, check out [*UCloud.Operations*](https://uralstech.github.io/UCloud.Operations/), which is included as a dependency when you install this
package.