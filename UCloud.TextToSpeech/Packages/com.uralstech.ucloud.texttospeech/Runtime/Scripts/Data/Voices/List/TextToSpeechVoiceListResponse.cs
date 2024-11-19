using Newtonsoft.Json;

namespace Uralstech.UCloud.TextToSpeech.Voices
{
    /// <summary>
    /// Response for a <see cref="TextToSpeechVoiceListRequest"/>.
    /// </summary>
    public class TextToSpeechVoiceListResponse
    {
        /// <summary>
        /// The list of voices.
        /// </summary>
        [JsonProperty("voices")]
        public TextToSpeechVoice[] Voices;
    }
}
