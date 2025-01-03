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
    /// 'audio effects' profiles that are applied on (post synthesized) text to speech.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TextToSpeechSynthesisProfile
    {
        /// <summary>
        /// Optimized for smart watches and other wearables, like Apple Watch, Wear OS watch.
        /// </summary>
        [EnumMember(Value = "wearable-class-device")]
        Wearable,

        /// <summary>
        /// Optimized for smartphones, like Google Pixel, Samsung Galaxy, Apple iPhone.
        /// </summary>
        [EnumMember(Value = "handset-class-device")]
        Handset,

        /// <summary>
        /// Optimized for small home speakers, like Google Home Mini.
        /// </summary>
        [EnumMember(Value = "small-bluetooth-speaker-class-device")]
        SmallBluetoothSpeaker,

        /// <summary>
        /// Optimized for smart home speakers, like Google Home.
        /// </summary>
        [EnumMember(Value = "medium-bluetooth-speaker-class-device")]
        MediumBluetoothSpeaker,

        /// <summary>
        /// Optimized for home entertainment systems or smart TVs, like Google Home Max, LG TV.
        /// </summary>
        [EnumMember(Value = "large-home-entertainment-class-device")]
        LargeHomeEntertainmentDevice,

        /// <summary>
        /// Optimized for car speakers.
        /// </summary>
        [EnumMember(Value = "large-automotive-class-device")]
        LargeAutomotiveDevice,

        /// <summary>
        /// Optimized for Interactive Voice Response (IVR) systems.
        /// </summary>
        [EnumMember(Value = "telephony-class-application")]
        TelephonyApplication,
    }
}