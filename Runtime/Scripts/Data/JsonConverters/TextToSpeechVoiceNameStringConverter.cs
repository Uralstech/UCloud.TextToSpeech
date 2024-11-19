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
