using System;
using System.Net.Http;
using PluginCalculator.Core.NativePlugins;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PluginCalculator.Core.Repositories.Result
{
	public class JsonResultRepository : IResultRepository
	{
		private readonly HttpClient _httpClient;
		private readonly ILogger _logger;

		public JsonResultRepository (ILogger logger)
		{
			_httpClient = new HttpClient ();
		}
			
		public string Execute (string mathString)
		{
			var url = string.Format ("http://staging.gerryhall.ca/math.php?q={0}", Uri.EscapeDataString (mathString));
			var result = _httpClient.GetStringAsync (url).Result;
			if (null != result) {
				var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>> (result);

				if (null != dictionary && dictionary.ContainsKey ("result"))
					return dictionary ["result"];
			}
			return null;
		}

	}
}