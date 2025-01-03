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
using System;

namespace Uralstech.UCloud.TextToSpeech
{
    /// <summary>
    /// Denotes the name of a TTS voice by its separate parts.
    /// </summary>
    [JsonConverter(typeof(TextToSpeechVoiceNameStringConverter))]
    public class TextToSpeechVoiceName
    {
        /// <summary>
        /// The fully formatted name of the voice.
        /// </summary>
        public string FullName => $"{LanguageCode}-{Type}-{Id}";

        /// <summary>
        /// The first part of the name, a <seealso href="https://www.rfc-editor.org/rfc/bcp/bcp47.txt">BCP-47</seealso> language code.
        /// </summary>
        public string LanguageCode;

        /// <summary>
        /// The second part of the name, the type, e.g. Neural2, Journey.
        /// </summary>
        public TextToSpeechVoiceType Type;

        /// <summary>
        /// The last part of the name, the single-character ID of the voice.
        /// </summary>
        public char Id;

        public TextToSpeechVoiceName() { }

        /// <param name="name">The name of the voice, in the format: "[<seealso href="https://www.rfc-editor.org/rfc/bcp/bcp47.txt">BCP-47</seealso> language code]-[Type]-[ID]".</param>
        public TextToSpeechVoiceName(string name)
        {
            string[] split = name.Split('-');
            LanguageCode = $"{split[0]}-{split[1]}";
            Type = Enum.Parse<TextToSpeechVoiceType>(split[2]);
            Id = split[3][0];
        }

        public static implicit operator TextToSpeechVoiceName(string value)
        {
            return new TextToSpeechVoiceName(value);
        }

        public static implicit operator string(TextToSpeechVoiceName value)
        {
            return value.FullName;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return FullName;
        }
    }
}
