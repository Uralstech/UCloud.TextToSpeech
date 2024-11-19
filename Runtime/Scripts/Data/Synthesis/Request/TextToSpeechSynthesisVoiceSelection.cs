using Newtonsoft.Json;

namespace Uralstech.UCloud.TextToSpeech.Synthesis
{
    /// <summary>
    /// Description of which voice to use for a synthesis request.
    /// </summary>
    public class TextToSpeechSynthesisVoiceSelection
    {
        /// <summary>
        /// The language (and potentially also the region) of the voice expressed as a
        /// <seealso href="https://www.rfc-editor.org/rfc/bcp/bcp47.txt">BCP-47</seealso>
        /// language tag, e.g. "en-US".
        /// </summary>
        /// <remarks>
        /// This should not include a script tag (e.g. use "cmn-cn" rather than "cmn-Hant-cn"),
        /// because the script will be inferred from the input provided in the <see cref="TextToSpeechSynthesisInput"/>.<br/>
        /// The TTS service will use this parameter to help choose an appropriate voice. Note
        /// that the TTS service may choose a voice with a slightly different language code<br/>
        /// than the one selected; it may substitute a different region (e.g. using en-US
        /// rather than en-CA if there isn't a Canadian voice available), or even a different<br/>
        /// language, e.g. using "nb" (Norwegian Bokmal) instead of "no" (Norwegian)".
        /// </remarks>
        [JsonProperty("languageCode")]
        public string LanguageCode;

        /// <summary>
        /// The name of the voice.
        /// </summary>
        /// <remarks>
        /// If both this and <see cref="Gender"/> are not set, the service will choose a voice
        /// based on the other parameters such as <see cref="LanguageCode"/>.
        /// </remarks>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public TextToSpeechVoiceName Name = null;

        /// <summary>
        /// The preferred gender of the voice.
        /// </summary>
        /// <remarks>
        /// If not set, the service will choose a voice based on the other parameters such as <see cref="LanguageCode"/><br/>
        /// and <see cref="Name"/>. Note that this is only a preference, not requirement; if a voice of the appropriate<br/>
        /// gender is not available, the synthesizer should substitute a voice with a different gender rather than failing the request.
        /// </remarks>
        [JsonProperty("ssmlGender", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TextToSpeechVoiceGender Gender = TextToSpeechVoiceGender.Default;

        /// <summary>
        /// The configuration for a custom voice.
        /// </summary>
        /// <remarks>
        /// If <see cref="TextToSpeechCustomVoiceParameters.Model"/> is set, the service will choose the custom voice matching the specified configuration.
        /// </remarks>
        [JsonProperty("customVoice", NullValueHandling = NullValueHandling.Ignore)]
        public TextToSpeechCustomVoiceParameters CustomVoiceParameters = null;
    }
}