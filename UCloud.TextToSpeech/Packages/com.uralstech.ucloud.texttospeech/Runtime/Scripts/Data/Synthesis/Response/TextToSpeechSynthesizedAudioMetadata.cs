using Newtonsoft.Json;

namespace Uralstech.UCloud.TextToSpeech.Synthesis
{
    /// <summary>
    /// The audio metadata for <see cref="TextToSpeechSynthesisResponse.Audio"/>.
    /// </summary>
    public class TextToSpeechSynthesizedAudioMetadata
    {
        /// <summary>
        /// The format of the audio byte stream.
        /// </summary>
        [JsonProperty("audioEncoding")]
        public TextToSpeechSynthesisAudioEncoding Encoding;

        /// <summary>
        /// The synthesis sample rate (in hertz) for this audio.
        /// </summary>
        [JsonProperty("sampleRateHertz")]
        public int SampleRateHertz;
    }
}