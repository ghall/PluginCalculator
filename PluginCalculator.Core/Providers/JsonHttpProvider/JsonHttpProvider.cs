using System;
using System.Net.Http;
using PluginCalculator.Core.NativePlugins;
using Newtonsoft.Json;
using System.Text;

namespace PluginCalculator.Core.Providers.JsonHttpProvider
{
	public class JsonHttpProvider : IJsonHttpProvider
	{
		private readonly HttpClient _httpClient;
		private readonly ILogger _logger;

		public JsonHttpProvider (ILogger logger)
		{
			_httpClient = new HttpClient ();
			_logger = logger;
		}

		public ApiResult<T> Get<T> (string url)
		{
			HttpResponseMessage result = null;
			try {
				lock (_httpClient) {
					_logger.Log(this, "Sending GET request to " + url);
					result = _httpClient.GetAsync(url).Result;
				}
				var rawResult = result.Content.ReadAsStringAsync().Result;

				return new ApiResult<T>(rawResult, JsonConvert.DeserializeObject<T>(rawResult));
			} catch (Exception e) {
				_logger.Log (this, "Error in GET: " + e.Message);
				_logger.Log (this, e.StackTrace);
			}

			return new ApiResult<T>(null, default(T));
		}

		public ApiResult<T> Post<T> (string url, string body)
		{
			HttpResponseMessage result = null;
			try {
				lock (_httpClient) {
					_logger.Log(this, "Sending POST request to " + url);
					result = _httpClient.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json")).Result;
				}
				var rawResult = result.Content.ReadAsStringAsync().Result;

				return new ApiResult<T>(rawResult, JsonConvert.DeserializeObject<T>(rawResult));
			} catch (Exception e) {
				_logger.Log (this, "Error in POST: " + e.Message);
				_logger.Log (this, e.StackTrace);
			}

			return new ApiResult<T>(null, default(T));
		}

		public ApiResult<T> Delete<T> (string url)
		{
			HttpResponseMessage result = null;
			try {
				lock (_httpClient) {
					_logger.Log(this, "Sending DELETE request to " + url);
					result = _httpClient.DeleteAsync(url).Result;
				}
				var rawResult = result.Content.ReadAsStringAsync().Result;

				return new ApiResult<T>(rawResult, JsonConvert.DeserializeObject<T>(rawResult));
			} catch (Exception e) {
				_logger.Log (this, "Error in DELETE: " + e.Message);
				_logger.Log (this, e.StackTrace);
			}

			return new ApiResult<T>(null, default(T));
		}       

		public ApiResult<T> Put<T> (string url, string body)
		{
			HttpResponseMessage result = null;
			try {
				lock (_httpClient) {
					_logger.Log(this, "Sending PUT request to " + url);
					result = _httpClient.PutAsync(url, new StringContent(body, Encoding.UTF8, "application/json")).Result;
				}
				var rawResult = result.Content.ReadAsStringAsync().Result;

				return new ApiResult<T>(rawResult, JsonConvert.DeserializeObject<T>(rawResult));
			} catch (Exception e) {
				_logger.Log (this, "Error in PUT: " + e.Message);
				_logger.Log (this, e.StackTrace);
			}

			return new ApiResult<T>(null, default(T));
		}       

	}
}