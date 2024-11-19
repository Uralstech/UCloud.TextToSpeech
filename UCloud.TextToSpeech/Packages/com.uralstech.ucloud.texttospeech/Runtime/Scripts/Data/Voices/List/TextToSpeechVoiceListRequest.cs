namespace Uralstech.UCloud.TextToSpeech.Voices
{
    /// <summary>
    /// Returns a list of Voice supported for synthesis. Response type is <see cref="TextToSpeechVoiceListResponse"/>.
    /// </summary>
    public class TextToSpeechVoiceListRequest : ITextToSpeechGetRequest
    {
        /// <summary>
        /// <seealso href="https://www.rfc-editor.org/rfc/bcp/bcp47.txt">BCP-47</seealso> language tag.
        /// </summary>
        /// <remarks>
        /// If not specified, the API will return all supported voices. If specified, the request call
        /// will only return voices that can be used to synthesize this language. For example, if you specify<br/>
        /// "en-NZ", all "en-NZ" voices will be returned. If you specify "no", both "no-\*" (Norwegian) and
        /// "nb-\*" (Norwegian Bokmal) voices will be returned.
        /// </remarks>
        public string LanguageCode;

        /// <inheritdoc/>
        public string UriParent { get; }

        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public TextToSpeechVoiceListRequest(bool useBetaApi = false)
        {
            UriParent = useBetaApi ? TextToSpeechManager.BetaApiUri : TextToSpeechManager.ProductionApiUri;
        }

        /// <inheritdoc/>
        public string GetEndpointUri()
        {
            return string.IsNullOrEmpty(LanguageCode)
                ? $"{UriParent}/voices"
                : $"{UriParent}/voices?languageCode={LanguageCode}";
        }
    }
}
