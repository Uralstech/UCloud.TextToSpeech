using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UCloud.TextToSpeech
{
    /// <summary>
    /// Gender of the voice as described in <seealso href="https://www.w3.org/TR/speech-synthesis11/#edef_voice">SSML voice element</seealso>.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TextToSpeechVoiceGender
    {
        /// <summary>
        /// Default value. Do not use.
        /// </summary>
        Default = 0,

        /// <summary>
        /// An unspecified gender.
        /// </summary>
        /// <remarks>
        /// In <see cref="Synthesis.TextToSpeechSynthesisVoiceSelection"/>, this means that the client doesn't care which gender the<br/>
        /// selected voice will have. In the <see cref="Voices.TextToSpeechVoiceListResponse.Voices"/> field of <see cref="Voices.TextToSpeechVoiceListResponse"/>,<br/>
        /// this may mean that the voice doesn't fit any of the other categories in this enum, or that the gender of the voice isn't known.
        /// </remarks>
        [EnumMember(Value = "SSML_VOICE_GENDER_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// A male voice.
        /// </summary>
        [EnumMember(Value = "MALE")]
        Male,

        /// <summary>
        /// A female voice.
        /// </summary>
        [EnumMember(Value = "FEMALE")]
        Female,

        /// <summary>
        /// A gender-neutral voice. This voice is not yet supported.
        /// </summary>
        [EnumMember(Value = "NEUTRAL")]
        Neutral,
    }
}