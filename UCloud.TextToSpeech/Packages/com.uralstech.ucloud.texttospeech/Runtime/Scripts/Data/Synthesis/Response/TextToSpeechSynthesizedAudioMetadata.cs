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

namespace Uralstech.UCloud.TextToSpeech.Synthesis
{
    /// <summary>
    /// The audio metadata for <see cref="TextToSpeechSynthesisResponse.Audio"/>.
    /// </summary>
    public class TextToSpeechSynthesizedAudioMetadata
    {
        /// <summary>
        /// The format of the audio byte stream.
        /// </summary>
        [JsonProperty("audioEncoding")]
        public TextToSpeechSynthesisAudioEncoding Encoding;

        /// <summary>
        /// The synthesis sample rate (in hertz) for this audio.
        /// </summary>
        [JsonProperty("sampleRateHertz")]
        public int SampleRateHertz;
    }
}