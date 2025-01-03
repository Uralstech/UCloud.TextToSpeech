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
        /// Timepoint information of &lt;mark&gt; tags in SSML input will be returned.
        /// </summary>
        [EnumMember(Value = "SSML_MARK")]
        SsmlMark,
    }
}