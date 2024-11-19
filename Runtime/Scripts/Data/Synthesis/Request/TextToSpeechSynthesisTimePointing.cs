using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UCloud.TextToSpeech.Synthesis
{
    /// <summary>
    /// The type of timepoint information that is returned in the response.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TextToSpeechSynthesisTimePointing
    {
        /// <summary>
        /// Default value. Do not use.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Not specified. No timepoint information will be returned.
        /// </summary>
        [EnumMember(Value = "TIMEPOINT_TYPE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Timepoint information of <mark> tags in SSML input will be returned.
        /// </summary>
        [EnumMember(Value = "SSML_MARK")]
        SsmlMark,
    }
}