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
    /// Converter to convert <see cref="TextToSpeechVoiceName"/> to a string and vice-versa.
    /// </summary>
    public class TextToSpeechVoiceNameStringConverter : JsonConverter<TextToSpeechVoiceName>
    {
        /// <inheritdoc/>/>
        public override TextToSpeechVoiceName ReadJson(JsonReader reader, Type objectType, TextToSpeechVoiceName existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new TextToSpeechVoiceName((string)reader.Value);
        }

        /// <inheritdoc/>/>
        public override void WriteJson(JsonWriter writer, TextToSpeechVoiceName value, JsonSerializer serializer)
        {
            writer.WriteValue(value.FullName);
        }
    }
}
