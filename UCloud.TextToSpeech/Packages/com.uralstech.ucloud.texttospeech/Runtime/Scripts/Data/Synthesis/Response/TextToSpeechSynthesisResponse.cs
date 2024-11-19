using System;
using System.IO;
using System.Threading.Tasks;
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
        public string Audio;

        /// <summary>
        /// Converts the base64 encoded audio to an <see cref="AudioClip"/>.
        /// </summary>
        /// <param name="encoding">The encoding of the audio.</param>
        /// <returns>The audio converted to an <see cref="AudioClip"/>.</returns>
        /// <exception cref="IOException">Thrown if <paramref name="encoding"/> is unsupported.</exception>
        public async Task<AudioClip> ToAudioClip(TextToSpeechSynthesisAudioEncoding encoding)
        {
            AudioType audioType = encoding switch
            {
                TextToSpeechSynthesisAudioEncoding.WavLinear16 or TextToSpeechSynthesisAudioEncoding.WavMuLaw or TextToSpeechSynthesisAudioEncoding.WavALaw => AudioType.WAV,
                TextToSpeechSynthesisAudioEncoding.Mp3 => AudioType.MPEG,
                _ => throw new IOException($"Unsupported audio format: {encoding}")
            };

            string path = Path.Combine(Application.temporaryCachePath, $"{nameof(TextToSpeechSynthesisResponse)}.bin");
            byte[] buffer = Convert.FromBase64String(Audio);
            File.WriteAllBytes(path, buffer);

            using UnityWebRequest audioClipRequest = UnityWebRequestMultimedia.GetAudioClip($"file://{path}", audioType);
            await audioClipRequest.SendWebRequest();

            return audioClipRequest.result == UnityWebRequest.Result.Success
                ? DownloadHandlerAudioClip.GetContent(audioClipRequest)
                : throw new IOException(audioClipRequest.error);
        }
    }
}