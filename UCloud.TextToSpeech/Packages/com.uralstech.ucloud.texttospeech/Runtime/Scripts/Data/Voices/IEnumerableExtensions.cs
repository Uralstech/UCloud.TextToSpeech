using System.Collections.Generic;
using System.Linq;

namespace Uralstech.UCloud.TextToSpeech.Voices
{
    /// <summary>
    /// Extensions for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Finds the voices with the given <paramref name="gender"/> and <paramref name="type"/> from the current collection.
        /// </summary>
        /// <param name="gender">The gender of the voice.</param>
        /// <param name="type">The type of the voice.</param>
        /// <returns>Voices with the type and gender corresponding to <paramref name="type"/> and <paramref name="gender"/>.</returns>
        public static IEnumerable<TextToSpeechVoice> FilterByAttributes(this IEnumerable<TextToSpeechVoice> thiz, TextToSpeechVoiceGender gender, TextToSpeechVoiceType type)
        {
            return from voice in thiz where voice.Gender == gender && voice.Name.Type == type select voice;
        }

        /// <summary>
        /// Finds the voices with the given <paramref name="gender"/> from the current collection.
        /// </summary>
        /// <param name="gender">The gender of the voice.</param>
        /// <returns>Voices with the gender corresponding to <paramref name="gender"/>.</returns>
        public static IEnumerable<TextToSpeechVoice> FilterByGender(this IEnumerable<TextToSpeechVoice> thiz, TextToSpeechVoiceGender gender)
        {
            return from voice in thiz where voice.Gender == gender select voice;
        }

        /// <summary>
        /// Finds the voices with the given <paramref name="type"/> from the current collection.
        /// </summary>
        /// <param name="type">The type of the voice.</param>
        /// <returns>Voices with the type corresponding to <paramref name="type"/>.</returns>
        public static IEnumerable<TextToSpeechVoice> FilterByType(this IEnumerable<TextToSpeechVoice> thiz, TextToSpeechVoiceType type)
        {
            return from voice in thiz where voice.Name.Type == type select voice;
        }

        /// <summary>
        /// Finds the voice with the given <paramref name="gender"/> and <paramref name="type"/> from the current collection.
        /// </summary>
        /// <param name="gender">The gender of the voice.</param>
        /// <param name="type">The type of the voice.</param>
        /// <returns>A voice with the type and gender corresponding to <paramref name="type"/> and <paramref name="gender"/>, <see langword="null"/> if not found.</returns>
        public static TextToSpeechVoice FindByAttributes(this IEnumerable<TextToSpeechVoice> thiz, TextToSpeechVoiceGender gender, TextToSpeechVoiceType type)
        {
            return thiz.FirstOrDefault(voice => voice.Gender == gender && voice.Name.Type == type);
        }

        /// <summary>
        /// Finds the voice with the given <paramref name="gender"/> from the current collection.
        /// </summary>
        /// <param name="gender">The gender of the voice.</param>
        /// <returns>A voice with the gender corresponding to <paramref name="gender"/>, <see langword="null"/> if not found.</returns>
        public static TextToSpeechVoice FindByGender(this IEnumerable<TextToSpeechVoice> thiz, TextToSpeechVoiceGender gender)
        {
            return thiz.FirstOrDefault(voice => voice.Gender == gender);
        }

        /// <summary>
        /// Finds the voice with the given <paramref name="type"/> from the current collection.
        /// </summary>
        /// <param name="type">The type of the voice.</param>
        /// <returns>A voice with the type corresponding to <paramref name="type"/>, <see langword="null"/> if not found.</returns>
        public static TextToSpeechVoice FindByType(this IEnumerable<TextToSpeechVoice> thiz, TextToSpeechVoiceType type)
        {
            return thiz.FirstOrDefault(voice => voice.Name.Type == type);
        }

        /// <summary>
        /// Finds the voice with the given <paramref name="name"/> from the current collection.
        /// </summary>
        /// <param name="name">The name of the voice.</param>
        /// <returns>A voice with the name corresponding to <paramref name="name"/>, <see langword="null"/> if not found.</returns>
        public static TextToSpeechVoice FindByName(this IEnumerable<TextToSpeechVoice> thiz, TextToSpeechVoiceName name)
        {
            string nameStr = name.FullName;
            return thiz.FirstOrDefault(voice => voice.Name.FullName == nameStr);
        }
    }
}