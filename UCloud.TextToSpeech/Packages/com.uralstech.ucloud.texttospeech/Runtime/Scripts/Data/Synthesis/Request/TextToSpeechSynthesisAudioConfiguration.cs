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
using System.ComponentModel;

namespace Uralstech.UCloud.TextToSpeech.Synthesis
{
    /// <summary>
    /// Description of audio data to be synthesized.
    /// </summary>
    public class TextToSpeechSynthesisAudioConfiguration
    {
        /// <summary>
        /// The format of the audio byte stream.
        /// </summary>
        [JsonProperty("audioEncoding")]
        public TextToSpeechSynthesisAudioEncoding Encoding;

        /// <summary>
        /// Speaking rate/speed, in the range [0.25, 4.0].
        /// </summary>
        /// <remarks>
        /// 1.0 is the normal native speed supported by the specific voice. 2.0 is twice as fast,<br/>
        /// and 0.5 is half as fast. If unset(0.0), defaults to the native 1.0 speed. Any other<br/>
        /// values &lt; 0.25 or &gt; 4.0 will return an error.
        /// </remarks>
        [JsonProperty("speakingRate", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(float.MinValue)]
        public float SpeakingRate = float.MinValue;

        /// <summary>
        /// Speaking pitch, in the range [-20.0, 20.0].
        /// </summary>
        /// <remarks>
        /// 20 means increase 20 semitones from the original pitch. -20 means decrease 20 semitones from the original pitch.
        /// </remarks>
        [JsonProperty("pitch", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(float.MinValue)]
        public float Pitch = float.MinValue;

        /// <summary>
        /// Volume gain (in dB) of the normal native volume supported by the specific voice, in the range [-96.0, 16.0].
        /// </summary>
        /// <remarks>
        /// If unset, or set to a value of 0.0 (dB), will play at normal native signal amplitude. A value of -6.0 (dB) will,<br/>
        /// play at approximately half the amplitude of the normal native signal amplitude. A value of +6.0 (dB) will play,<br/>
        /// at approximately twice the amplitude of the normal native signal amplitude. Strongly recommend not to exceed +10,<br/>
        /// (dB) as there's usually no effective increase in loudness for any value greater than that.
        /// </remarks>
        [JsonProperty("volumeGainDb", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(float.MinValue)]
        public float VolumeGainDb = float.MinValue;

        /// <summary>
        /// The synthesis sample rate (in hertz) for this audio.
        /// </summary>
        /// <remarks>
        /// When this is specified in <see cref="TextToSpeechSynthesisRequest"/>, if this is different from the voice's natural<br/>
        /// sample rate, then the synthesizer will honor this request by converting to the desired sample rate (which might result<br/>
        /// in worse audio quality), unless the specified sample rate is not supported for the encoding chosen, in which case it<br/>
        /// will fail the request and return <c>google.rpc.Code.INVALID_ARGUMENT</c>.
        /// </remarks>
        [JsonProperty("sampleRateHertz", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(int.MinValue)]
        public int SampleRateHertz = int.MinValue;

        /// <summary>
        /// 'audio effects' profiles that are applied on (post synthesized) text to speech.
        /// </summary>
        /// <remarks>
        /// Effects are applied on top of each other in the order they are given.
        /// See <seealso href="https://cloud.google.com/text-to-speech/docs/audio-profiles">audio profiles</seealso> for current supported profile ids.
        /// </remarks>
        [JsonProperty("effectsProfileId", NullValueHandling = NullValueHandling.Ignore)]
        public TextToSpeechSynthesisProfile[] EffectsProfiles = null;

        public TextToSpeechSynthesisAudioConfiguration() { }

        /// <param name="encoding">See <see cref="Encoding"/>.</param>
        public TextToSpeechSynthesisAudioConfiguration(TextToSpeechSynthesisAudioEncoding encoding)
        {
            Encoding = encoding;
        }
    }
}