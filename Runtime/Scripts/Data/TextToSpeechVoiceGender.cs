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