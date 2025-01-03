// Copyright 2024 URAV ADVANCED LEARNING SYSTEMS PRIVATE LIMITED
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
        /// 
        /// <br/><br/>
        /// This encoding is not supported by the plugin. You will have to
        /// convert the resulting bytes to an AudioClip yourself.
        /// </summary>
        [EnumMember(Value = "MULAW")]
        WavMuLaw,

        /// <summary>
        /// 8-bit samples that compand 14-bit audio samples using G.711 PCMU/A-law.
        /// Audio content returned as ALAW also contains a WAV header.
        /// 
        /// <br/><br/>
        /// This encoding is not supported by the plugin. You will have to
        /// convert the resulting bytes to an AudioClip yourself.
        /// </summary>
        [EnumMember(Value = "ALAW")]
        WavALaw
    }
}