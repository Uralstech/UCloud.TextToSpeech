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

namespace Uralstech.UCloud.TextToSpeech.Voices
{
    /// <summary>
    /// Description of a voice supported by the TTS service.
    /// </summary>
    public class TextToSpeechVoice
    {
        /// <summary>
        /// The languages that this voice supports, expressed as <seealso href="https://www.rfc-editor.org/rfc/bcp/bcp47.txt">BCP-47</seealso> language tags (e.g. "en-US", "es-419", "cmn-tw").
        /// </summary>
        [JsonProperty("languageCodes")]
        public string[] SupportedLanguages;

        /// <summary>
        /// The name of this voice. Each distinct voice has a unique name.
        /// </summary>
        [JsonProperty("name")]
        public TextToSpeechVoiceName Name;

        /// <summary>
        /// The gender of this voice.
        /// </summary>
        [JsonProperty("ssmlGender")]
        public TextToSpeechVoiceGender Gender;

        /// <summary>
        /// The natural sample rate (in hertz) for this voice.
        /// </summary>
        [JsonProperty("naturalSampleRateHertz")]
        public int NaturalSampleRateHertz;
    }
}
