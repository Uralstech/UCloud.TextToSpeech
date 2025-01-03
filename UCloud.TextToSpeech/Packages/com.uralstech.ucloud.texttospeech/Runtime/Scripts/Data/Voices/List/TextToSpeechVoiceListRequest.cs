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

namespace Uralstech.UCloud.TextToSpeech.Voices
{
    /// <summary>
    /// Returns a list of Voice supported for synthesis. Response type is <see cref="TextToSpeechVoiceListResponse"/>.
    /// </summary>
    public class TextToSpeechVoiceListRequest : ITextToSpeechGetRequest
    {
        /// <summary>
        /// <seealso href="https://www.rfc-editor.org/rfc/bcp/bcp47.txt">BCP-47</seealso> language tag.
        /// </summary>
        /// <remarks>
        /// If not specified, the API will return all supported voices. If specified, the request call
        /// will only return voices that can be used to synthesize this language. For example, if you specify<br/>
        /// "en-NZ", all "en-NZ" voices will be returned. If you specify "no", both "no-\*" (Norwegian) and
        /// "nb-\*" (Norwegian Bokmal) voices will be returned.
        /// </remarks>
        public string LanguageCode;

        /// <inheritdoc/>
        public string UriParent { get; }

        /// <param name="languageCode">See <see cref="LanguageCode"/>.</param>
        /// <param name="useBetaApi">Should the request use the Beta API?</param>
        public TextToSpeechVoiceListRequest(string languageCode = null, bool useBetaApi = false)
        {
            LanguageCode = languageCode;
            UriParent = useBetaApi ? TextToSpeechManager.BetaApiUri : TextToSpeechManager.ProductionApiUri;
        }

        /// <inheritdoc/>
        public string GetEndpointUri()
        {
            return string.IsNullOrEmpty(LanguageCode)
                ? $"{UriParent}/voices"
                : $"{UriParent}/voices?languageCode={LanguageCode}";
        }
    }
}
