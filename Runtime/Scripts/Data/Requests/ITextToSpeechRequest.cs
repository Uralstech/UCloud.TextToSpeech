namespace Uralstech.UCloud.TextToSpeech
{
    /// <summary>
    /// All TTS API requests must inherit from this interface.
    /// </summary>
    public interface ITextToSpeechRequest
    {
        /// <summary>
        /// Gets the URI to the API endpoint.
        /// </summary>
        /// <returns>The URI.</returns>
        public string GetEndpointUri();

        /// <summary>
        /// The base endpoint URI + version.
        /// </summary>
        public string UriParent { get; }
    }
}
