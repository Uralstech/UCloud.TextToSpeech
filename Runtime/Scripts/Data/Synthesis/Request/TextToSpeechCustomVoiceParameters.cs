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

        /// <param name="model">See <see cref="Model"/>.</param>
        public TextToSpeechCustomVoiceParameters(string model)
        {
            Model = model;
        }
    }
}