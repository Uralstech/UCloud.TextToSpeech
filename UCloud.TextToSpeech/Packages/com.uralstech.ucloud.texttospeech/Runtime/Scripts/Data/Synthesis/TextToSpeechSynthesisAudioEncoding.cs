using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UCloud.TextToSpeech.Synthesis
{
    /// <summary>
    /// Configuration to set up audio encoder. The encoding determines the output audio format that we'd like.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TextToSpeechSynthesisAudioEncoding
    {
        /// <summary>
        /// Default value. Will return result <c>google.rpc.Code.INVALID_ARGUMENT</c>.
        /// </summary>
        [EnumMember(Value = "AUDIO_ENCODING_UNSPECIFIED")]
        Default = 0,

        /// <summary>
        /// Uncompressed 16-bit signed little-endian samples (Linear PCM).
        /// Audio content returned as LINEAR16 also contains a WAV header.
        /// </summary>
        [EnumMember(Value = "LINEAR16")]
        WavLinear16,

        /// <summary>
        /// MP3 audio at 32kbps.
        /// </summary>
        [EnumMember(Value = "MP3")]
        Mp3,

        /// <summary>
        /// MP3 at 64kbps. Requires the beta API.
        /// </summary>
        [EnumMember(Value = "MP3_64_KBPS")]
        Mp3_64Kbps,

        /// <summary>
        /// Opus encoded audio wrapped in an ogg container.
        /// </summary>
        /// <remarks>
        /// The result will be a file which can be played natively on Android,
        /// and in browsers (at least Chrome and Firefox). The quality of the<br/>
        /// encoding is considerably higher than MP3 while using approximately
        /// the same bitrate.
        /// 
        /// <br/><br/>
        /// This encoding is not supported by the plugin. You will have to
        /// convert the resulting bytes to an AudioClip yourself.
        /// </remarks>
        [EnumMember(Value = "OGG_OPUS")]
        OggOpus,

        /// <summary>
        /// 8-bit samples that compand 14-bit audio samples using G.711 PCMU/mu-law.
        /// Audio content returned as MULAW also contains a WAV header.
        /// </summary>
        [EnumMember(Value = "MULAW")]
        WavMuLaw,

        /// <summary>
        /// 8-bit samples that compand 14-bit audio samples using G.711 PCMU/A-law.
        /// Audio content returned as ALAW also contains a WAV header.
        /// </summary
        [EnumMember(Value = "ALAW")]
        WavALaw
    }
}