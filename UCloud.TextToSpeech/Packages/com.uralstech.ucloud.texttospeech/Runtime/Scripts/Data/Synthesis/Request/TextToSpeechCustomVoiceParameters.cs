using Newtonsoft.Json;

namespace Uralstech.UCloud.TextToSpeech.Synthesis
{
    /// <summary>
    /// Description of the custom voice to be synthesized.
    /// </summary>
    public class TextToSpeechCustomVoiceParameters
    {
        /// <summary>
        /// The name of the AutoML model that synthesizes the custom voice.
        /// </summary>
        [JsonProperty("model")]
        public string Model;
    }
}