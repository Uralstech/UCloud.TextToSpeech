using Newtonsoft.Json;

namespace Uralstech.UCloud.TextToSpeech.Voices
{
    /// <summary>
    /// Description of a voice supported by the TTS service.
    /// </summary>
    public class TextToSpeechVoice
    {
        /// <summary>
        /// The languages that this voice supports, expressed as <seealso href="https://www.rfc-editor.org/rfc/bcp/bcp47.txt">BCP-47</seealso> language tags (e.g. "en-US", "es-419", "cmn-tw").
        /// </summary>
        [JsonProperty("languageCodes")]
        public string[] SupportedLanguages;

        /// <summary>
        /// The name of this voice. Each distinct voice has a unique name.
        /// </summary>
        [JsonProperty("name")]
        public TextToSpeechVoiceName Name;

        /// <summary>
        /// The gender of this voice.
        /// </summary>
        [JsonProperty("ssmlGender")]
        public TextToSpeechVoiceGender Gender;

        /// <summary>
        /// The natural sample rate (in hertz) for this voice.
        /// </summary>
        [JsonProperty("naturalSampleRateHertz")]
        public int NaturalSampleRateHertz;
    }
}
