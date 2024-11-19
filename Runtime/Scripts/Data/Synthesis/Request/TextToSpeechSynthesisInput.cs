using Newtonsoft.Json;

namespace Uralstech.UCloud.TextToSpeech.Synthesis
{
    /// <summary>
    /// Contains text input to be synthesized.
    /// </summary>
    /// <remarks>
    /// Either <see cref="Text"/> or <see cref="Ssml"/> must be supplied. Supplying both or
    /// neither returns <c>google.rpc.Code.INVALID_ARGUMENT</c>. The input size is limited
    /// to 5000 bytes.
    /// </remarks>
    public class TextToSpeechSynthesisInput
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text = null;

        /// <summary>
        /// The SSML document to be synthesized.
        /// </summary>
        /// <remarks>
        /// The SSML document must be valid and well-formed. Otherwise the RPC will fail and
        /// return <c>google.rpc.Code.INVALID_ARGUMENT</c>. For more information, see <seealso href="https://cloud.google.com/text-to-speech/docs/ssml">SSML</seealso>.
        /// </remarks>
        [JsonProperty("ssml", NullValueHandling = NullValueHandling.Ignore)]
        public string Ssml = null;

        public TextToSpeechSynthesisInput() { }

        /// <param name="input">The input.</param>
        /// <param name="isSsml">Is the input SSML or normal text?</param>
        public TextToSpeechSynthesisInput(string input, bool isSsml = false)
        {
            if (isSsml)
                Ssml = input;
            else
                Text = input;
        }
    }
}