using Newtonsoft.Json;
using System;
using UnityEngine;
using UnityEngine.Networking;
using Uralstech.UCloud.TextToSpeech.Exceptions;
using Uralstech.Utils.Singleton;

namespace Uralstech.UCloud.TextToSpeech
{
    /// <summary>
    /// The class for accessing the Google Cloud Text-To-Speech API!
    /// </summary>
    [AddComponentMenu("Uralstech/UCloud/Text To Speech/Text To Speech Manager")]
    public class TextToSpeechManager : Singleton<TextToSpeechManager>
    {
        /// <summary>
        /// The base URI to the Text To Speech service.
        /// </summary>
        public const string BaseServiceUri = "https://texttospeech.googleapis.com";

        /// <summary>
        /// The production v1 API URI to the Text To Speech service.
        /// </summary>
        public const string ProductionApiUri = "https://texttospeech.googleapis.com/v1";

        /// <summary>
        /// The beta API URI to the Text To Speech service.
        /// </summary>
        public const string BetaApiUri = "https://texttospeech.googleapis.com/v1beta1";

        /// <summary>
        /// An empty JSON object.
        /// </summary>
        private const string EmptyJsonObject = "{}";

        [SerializeField, Tooltip("Your Text To Speech API key.")] private string _textToSpeechApiKey;

        /// <summary>
        /// Sets the Text To Speech API key.
        /// </summary>
        /// <param name="apiKey">The new API key.</param>
        public void SetApiKey(string apiKey)
        {
            _textToSpeechApiKey = apiKey;
        }

        /// <summary>
        /// Computes a POST request on the TTS API.
        /// </summary>
        /// 
        /// <typeparam name="TResponse">
        /// The response type. For example, a request of type <see cref="Synthesis.TextToSpeechSynthesisRequest"/> corresponds
        /// to a response type of <see cref="Synthesis.TextToSpeechSynthesisResponse"/>.
        /// </typeparam>
        /// 
        /// <param name="request">The request object.</param>
        /// <returns>The computed response.</returns>
        /// <exception cref="TextToSpeechRequestException">Thrown if the API request fails.</exception>
        /// <exception cref="TextToSpeechResponseParsingException">Thrown if the response could not be parsed.</exception>
        public async Awaitable<TResponse> Request<TResponse>(ITextToSpeechPostRequest request)
        {
            await Awaitable.MainThreadAsync();
            string utf8RequestData = request.GetUtf8EncodedData();
            string requestEndpoint = request.GetEndpointUri();

            using UnityWebRequest webRequest = UnityWebRequest.Post(requestEndpoint, utf8RequestData, request.ContentType);
            SetupWebRequest(webRequest);

            await webRequest.SendWebRequest();
            CheckWebRequest(webRequest);

            return ConfirmResponse<TResponse>(webRequest);
        }

        /// <summary>
        /// Computes a GET request on the TTS API.
        /// </summary>
        /// 
        /// <typeparam name="TResponse">
        /// The response type. For example, a request of type <see cref="Synthesis.TextToSpeechSynthesisRequest"/> corresponds
        /// to a response type of <see cref="Synthesis.TextToSpeechSynthesisResponse"/>.
        /// </typeparam>
        /// 
        /// <param name="request">The request object.</param>
        /// <returns>The computed response.</returns>
        /// <exception cref="TextToSpeechRequestException">Thrown if the API request fails.</exception>
        /// <exception cref="TextToSpeechResponseParsingException">Thrown if the response could not be parsed.</exception>
        public async Awaitable<TResponse> Request<TResponse>(ITextToSpeechGetRequest request)
        {
            await Awaitable.MainThreadAsync();
            string requestEndpoint = request.GetEndpointUri();

            using UnityWebRequest webRequest = UnityWebRequest.Get(requestEndpoint);
            SetupWebRequest(webRequest);

            await webRequest.SendWebRequest();
            CheckWebRequest(webRequest);

            return ConfirmResponse<TResponse>(webRequest);
        }

        /// <summary>
        /// Sets up the <see cref="UnityWebRequest"/> with API keys and disposal settings.
        /// </summary>
        /// <param name="webRequest">The request to set up.</param>
        private void SetupWebRequest(UnityWebRequest webRequest)
        {
            webRequest.SetRequestHeader("X-goog-api-key", _textToSpeechApiKey);
            webRequest.disposeUploadHandlerOnDispose = true;
            webRequest.disposeDownloadHandlerOnDispose = true;
        }

        /// <summary>
        /// Checks the given <see cref="UnityWebRequest"/> for errors.
        /// </summary>
        /// <param name="webRequest">The request to check.</param>
        /// <exception cref="TextToSpeechRequestException">Thrown if the request was not successful.</exception>
        private void CheckWebRequest(UnityWebRequest webRequest)
        {
            if (webRequest.result != UnityWebRequest.Result.Success)
                throw new TextToSpeechRequestException(webRequest);

            Debug.Log("TTS API computation succeeded.");
        }

        /// <summary>
        /// Checks if the downloaded response was correct.
        /// </summary>
        /// <typeparam name="TResponse">The expected response type.</typeparam>
        /// <param name="request">The web request.</param>
        /// <exception cref="TextToSpeechResponseParsingException">Thrown if the response could not be parsed.</exception>
        private TResponse ConfirmResponse<TResponse>(UnityWebRequest request)
        {
            try
            {
                return JsonConvert.DeserializeObject<TResponse>(request.downloadHandler?.text);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to confirm successful API response:\n{e}");
                throw new TextToSpeechResponseParsingException(request, e);
            }
        }

        /// <summary>
        /// Checks if the downloaded response was empty, as to be expected of some endpoints.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <exception cref="TextToSpeechResponseParsingException">Thrown if the response was not empty.</exception>
        private void ConfirmResponse(UnityWebRequest request)
        {
            if (!string.IsNullOrEmpty(request.downloadHandler?.text) && request.downloadHandler.text.Trim() != EmptyJsonObject)
            {
                Debug.LogError($"Failed to confirm successful API response:\n{request.downloadHandler?.text}");
                throw new TextToSpeechResponseParsingException(request);
            }
        }
    }
}