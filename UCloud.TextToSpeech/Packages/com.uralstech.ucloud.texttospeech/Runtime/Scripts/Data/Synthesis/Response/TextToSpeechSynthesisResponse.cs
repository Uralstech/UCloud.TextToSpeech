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
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Uralstech.UCloud.TextToSpeech.Synthesis
{
    /// <summary>
    /// Response for a <see cref="TextToSpeechSynthesisRequest"/>.
    /// </summary>
    public class TextToSpeechSynthesisResponse
    {
        /// <summary>
        /// The audio data bytes encoded as specified in the request, including the header for encodings that are wrapped in containers (e.g. MP3, OGG_OPUS).
        /// </summary>
        /// <remarks>
        /// For LINEAR16 audio, we include the WAV header. Note: as with all bytes fields, protobuffers use a pure binary representation, whereas JSON representations use base64.
        /// </remarks>
        [JsonProperty("audioContent")]
        public string Audio;

        /// <summary>
        /// A link between a position in the original request input and a corresponding time in the output audio. It's only supported via &lt;mark&gt; of SSML input. Only returned when using the beta API.
        /// </summary>
        [JsonProperty("timepoints")]
        public TextToSpeechSynthesisTimePoint[] TimePoints;

        /// <summary>
        /// The audio metadata for <see cref="Audio"/>. Only returned when using the beta API.
        /// </summary>
        [JsonProperty("audioConfig")]
        public TextToSpeechSynthesizedAudioMetadata AudioMetadata;

        /// <summary>
        /// Converts the base64 encoded audio to an <see cref="AudioClip"/>.
        /// </summary>
        /// <param name="encoding">The encoding of the audio.</param>
        /// <returns>The audio converted to an <see cref="AudioClip"/>.</returns>
        /// <exception cref="IOException">Thrown if <paramref name="encoding"/> is unsupported.</exception>
        public async Awaitable<AudioClip> ToAudioClip(TextToSpeechSynthesisAudioEncoding encoding)
        {
            await Awaitable.MainThreadAsync();
            AudioType audioType = encoding switch
            {
                TextToSpeechSynthesisAudioEncoding.WavLinear16 => AudioType.WAV,
                TextToSpeechSynthesisAudioEncoding.Mp3 or TextToSpeechSynthesisAudioEncoding.Mp3_64Kbps => AudioType.MPEG,
                _ => throw new IOException($"Unsupported audio format: {encoding}")
            };

            string path = Path.Combine(Application.temporaryCachePath, $"{nameof(TextToSpeechSynthesisResponse)}.bin");
            byte[] buffer = Convert.FromBase64String(Audio);
            await File.WriteAllBytesAsync(path, buffer);

            using UnityWebRequest audioClipRequest = UnityWebRequestMultimedia.GetAudioClip($"file://{path}", audioType);
            await audioClipRequest.SendWebRequest();

            return audioClipRequest.result == UnityWebRequest.Result.Success
                ? DownloadHandlerAudioClip.GetContent(audioClipRequest)
                : throw new IOException(audioClipRequest.error);
        }

        /// <summary>
        /// Converts the base64 encoded audio to an <see cref="AudioClip"/>. Requires the the beta API.
        /// </summary>
        /// <returns>The audio converted to an <see cref="AudioClip"/>.</returns>
        /// <exception cref="IOException">Thrown if <paramref name="encoding"/> is unsupported.</exception>
        public async Awaitable<AudioClip> ToAudioClip()
        {
            return await ToAudioClip(AudioMetadata?.Encoding ?? TextToSpeechSynthesisAudioEncoding.Default);
        }
    }
}