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

using System;
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
            return from voice in thiz where voice?.Gender == gender && voice?.Name?.Type == type select voice;
        }

        /// <summary>
        /// Finds the voices with the given <paramref name="gender"/> from the current collection.
        /// </summary>
        /// <param name="gender">The gender of the voice.</param>
        /// <returns>Voices with the gender corresponding to <paramref name="gender"/>.</returns>
        public static IEnumerable<TextToSpeechVoice> FilterByGender(this IEnumerable<TextToSpeechVoice> thiz, TextToSpeechVoiceGender gender)
        {
            return from voice in thiz where voice?.Gender == gender select voice;
        }

        /// <summary>
        /// Finds the voices with the given <paramref name="type"/> from the current collection.
        /// </summary>
        /// <param name="type">The type of the voice.</param>
        /// <returns>Voices with the type corresponding to <paramref name="type"/>.</returns>
        public static IEnumerable<TextToSpeechVoice> FilterByType(this IEnumerable<TextToSpeechVoice> thiz, TextToSpeechVoiceType type)
        {
            return from voice in thiz where voice?.Name?.Type == type select voice;
        }

        /// <summary>
        /// Finds the voice with the given <paramref name="gender"/> and <paramref name="type"/> from the current collection.
        /// </summary>
        /// <param name="gender">The gender of the voice.</param>
        /// <param name="type">The type of the voice.</param>
        /// <returns>A voice with the type and gender corresponding to <paramref name="type"/> and <paramref name="gender"/>, <see langword="null"/> if not found.</returns>
        public static TextToSpeechVoice FindByAttributes(this IEnumerable<TextToSpeechVoice> thiz, TextToSpeechVoiceGender gender, TextToSpeechVoiceType type)
        {
            return thiz.FirstOrDefault(voice => voice?.Gender == gender && voice?.Name?.Type == type);
        }

        /// <summary>
        /// Finds the first voice with the given <paramref name="gender"/> and one of the specified <paramref name="types"/>,
        /// where the order of types in <paramref name="types"/> specifies preference. 
        /// </summary>
        /// <remarks>
        /// The method searches the collection and returns the first voice that matches the gender and any of the provided types, 
        /// preferring the order in which the types are listed.
        /// </remarks>
        /// <param name="thiz">The collection of voices to search within.</param>
        /// <param name="gender">The gender to filter by.</param>
        /// <param name="types">The types to filter by. Order indicates preference.</param>
        /// <returns>The first voice matching the gender and one of the specified types, or null if none is found.</returns>
        public static TextToSpeechVoice FindByAttributes(this IEnumerable<TextToSpeechVoice> thiz, TextToSpeechVoiceGender gender, params TextToSpeechVoiceType[] types)
        {
            if (types.Length < 2)
                return types.Length == 0 ? FindByGender(thiz, gender) : FindByAttributes(thiz, gender, types[0]);

            Dictionary<TextToSpeechVoiceType, TextToSpeechVoice> foundVoices = new(types.Length);
            foreach (TextToSpeechVoice voice in thiz)
            {
                if (voice?.Gender != gender)
                    continue;

                TextToSpeechVoiceType type = voice.Name.Type;
                int index = Array.IndexOf(types, type);

                if (index == 0)
                    return voice;
                else if (index >= 0 && !foundVoices.ContainsKey(type))
                    foundVoices[type] = voice;
            }

            return (from type in types where foundVoices.ContainsKey(type) select foundVoices[type]).FirstOrDefault();
        }

        /// <summary>
        /// Finds the voice with the given <paramref name="gender"/> from the current collection.
        /// </summary>
        /// <param name="gender">The gender of the voice.</param>
        /// <returns>A voice with the gender corresponding to <paramref name="gender"/>, <see langword="null"/> if not found.</returns>
        public static TextToSpeechVoice FindByGender(this IEnumerable<TextToSpeechVoice> thiz, TextToSpeechVoiceGender gender)
        {
            return thiz.FirstOrDefault(voice => voice?.Gender == gender);
        }

        /// <summary>
        /// Finds the voice with the given <paramref name="type"/> from the current collection.
        /// </summary>
        /// <param name="type">The type of the voice.</param>
        /// <returns>A voice with the type corresponding to <paramref name="type"/>, <see langword="null"/> if not found.</returns>
        public static TextToSpeechVoice FindByType(this IEnumerable<TextToSpeechVoice> thiz, TextToSpeechVoiceType type)
        {
            return thiz.FirstOrDefault(voice => voice?.Name?.Type == type);
        }

        /// <summary>
        /// Finds the voice with the given <paramref name="name"/> from the current collection.
        /// </summary>
        /// <param name="name">The name of the voice.</param>
        /// <returns>A voice with the name corresponding to <paramref name="name"/>, <see langword="null"/> if not found.</returns>
        public static TextToSpeechVoice FindByName(this IEnumerable<TextToSpeechVoice> thiz, TextToSpeechVoiceName name)
        {
            string nameStr = name?.FullName;
            return thiz.FirstOrDefault(voice => voice?.Name?.FullName == nameStr);
        }
    }
}