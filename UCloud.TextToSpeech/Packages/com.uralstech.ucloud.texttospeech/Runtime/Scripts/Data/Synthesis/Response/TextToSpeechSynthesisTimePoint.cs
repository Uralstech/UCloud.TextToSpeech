using Newtonsoft.Json;

namespace Uralstech.UCloud.TextToSpeech.Synthesis
{
    /// <summary>
    /// This contains a mapping between a certain point in the input text and a corresponding time in the output audio.
    /// </summary>
    public class TextToSpeechSynthesisTimePoint
    {
        /// <summary>
        /// Timepoint name as received from the client within <mark> tag.
        /// </summary>
        [JsonProperty("markName")]
        public string MarkName;

        /// <summary>
        /// Time offset in seconds from the start of the synthesized audio.
        /// </summary>
        [JsonProperty("timeSeconds")]
        public float TimeSeconds;
    }
}