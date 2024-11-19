using Newtonsoft.Json;

namespace Uralstech.UCloud.TextToSpeech.Synthesis
{
    /// <summary>
    /// Request to synthesize audio from the given text. Response type is <see cref="TextToSpeechSynthesisResponse"/>.
    /// </summary>
    public class TextToSpeechSynthesisRequest : ITextToSpeechPostRequest
    {
        /// <summary>
        /// The Synthesizer requires either plain text or SSML as input.
        /// </summary>
        [JsonProperty("input")]
        public TextToSpeechSynthesisInput Input;

        /// <summary>
        /// The desired voice of the synthesized audio.
        /// </summary>
        [JsonProperty("voice")]
        public TextToSpeechSynthesisVoiceSelection Voice;

        /// <summary>
        /// The configuration of the synthesized audio.
        /// </summary>
        [JsonProperty("audioConfig")]
        public TextToSpeechSynthesisAudioConfiguration AudioConfiguration;

        /// <summary>
        /// Whether and what timepoints are returned in the response. Requires the beta API.
        /// </summary>
        [JsonProperty("enableTimePointing", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TextToSpeechSynthesisTimePointing EnableTimePointing = TextToSpeechSynthesisTimePointing.Default;

        /// <inheritdoc/>
        [JsonIgnore]
        public string ContentType => "application/json";

        /// <inheritdoc/>
        [JsonIgnore]
        public string UriParent { get; }

        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public TextToSpeechSynthesisRequest(bool useBetaApi = false)
        {
            UriParent = useBetaApi ? TextToSpeechManager.BetaApiUri : TextToSpeechManager.ProductionApiUri;
        }

        /// <inheritdoc/>
        public string GetEndpointUri()
        {
            return $"{UriParent}/text:synthesize";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}