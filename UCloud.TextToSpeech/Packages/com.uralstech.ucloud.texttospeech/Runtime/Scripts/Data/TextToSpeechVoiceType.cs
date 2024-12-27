namespace Uralstech.UCloud.TextToSpeech
{
    /// <summary>
    /// The types of voices supported by the TTS API.
    /// </summary>
    public enum TextToSpeechVoiceType
    {
        /// <summary>
        /// Default value, ignore.
        /// </summary>
        None,

        /// <summary>
        /// <seealso href="https://cloud.google.com/text-to-speech/docs/voice-types#standard_voices">Standard</seealso>
        /// </summary>
        Standard,

        /// <summary>
        /// <seealso href="https://cloud.google.com/text-to-speech/docs/wavenet">Wavenet</seealso>
        /// </summary>
        Wavenet,

        /// <summary>
        /// <seealso href="https://cloud.google.com/text-to-speech/docs/voice-types#neural2_voices">Neural2</seealso>
        /// </summary>
        Neural2,

        /// <summary>
        /// <seealso href="https://cloud.google.com/text-to-speech/docs/voice-types#journey_voices">Journey</seealso>
        /// </summary>
        Journey,

        /// <summary>
        /// <seealso href="https://cloud.google.com/text-to-speech/docs/polyglot">Polyglot</seealso>
        /// </summary>
        Polyglot,

        /// <summary>
        /// <seealso href="https://cloud.google.com/text-to-speech/docs/voice-types#studio_voices">Studio</seealso>
        /// </summary>
        Studio,

        /// <summary>
        /// <seealso href="https://cloud.google.com/text-to-speech/docs/voice-types">News</seealso>
        /// </summary>
        News,

        /// <summary>
        /// <seealso href="https://cloud.google.com/text-to-speech/docs/voice-types">Casual</seealso>
        /// </summary>
        Casual
    }
}
