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
    /// Request to synthesize audio from the given text. Response type is <see cref="TextToSpeechSynthesisResponse"/>.
    /// </summary>
    public class TextToSpeechSynthesisRequest : ITextToSpeechPostRequest
    {
        /// <summary>
        /// The Synthesizer requires either plain text or SSML as input.
        /// </summary>
        [JsonProperty("input")]
        public TextToSpeechSynthesisInput Input;

        /// <summary>
        /// The desired voice of the synthesized audio.
        /// </summary>
        [JsonProperty("voice")]
        public TextToSpeechSynthesisVoiceSelection Voice;

        /// <summary>
        /// The configuration of the synthesized audio.
        /// </summary>
        [JsonProperty("audioConfig")]
        public TextToSpeechSynthesisAudioConfiguration AudioConfiguration;

        /// <summary>
        /// Whether and what timepoints are returned in the response. Requires the beta API.
        /// </summary>
        [JsonProperty("enableTimePointing", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TextToSpeechSynthesisTimePointing EnableTimePointing = TextToSpeechSynthesisTimePointing.Default;

        /// <inheritdoc/>
        [JsonIgnore]
        public string ContentType => "application/json";

        /// <inheritdoc/>
        [JsonIgnore]
        public string UriParent { get; }

        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public TextToSpeechSynthesisRequest(bool useBetaApi = false)
        {
            UriParent = useBetaApi ? TextToSpeechManager.BetaApiUri : TextToSpeechManager.ProductionApiUri;
        }

        /// <inheritdoc/>
        public string GetEndpointUri()
        {
            return $"{UriParent}/text:synthesize";
        }

        /// <inheritdoc/>
        public string GetUtf8EncodedData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}