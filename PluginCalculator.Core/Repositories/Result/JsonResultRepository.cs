using System;
using System.Net.Http;
using PluginCalculator.Core.NativePlugins;
using Newtonsoft.Json;
using System.Collections.Generic;
using PluginCalculator.Core.Providers.JsonHttpProvider;

namespace PluginCalculator.Core.Repositories.Result
{
	public class JsonResultRepository : IResultRepository
	{
		private readonly IJsonHttpProvider _httpProvider;
		private readonly ILogger _logger;

		public JsonResultRepository (ILogger logger, IJsonHttpProvider httpProvider)
		{
			_logger = logger;
			_httpProvider = httpProvider;
		}
			
		public string Execute (string mathString)
		{
			try {
				var url = string.Format ("http://staging.gerryhall.ca/math.php?q={0}", Uri.EscapeDataString (mathString));
				var result = _httpProvider.Get<Dictionary<string, string>> (url);

				if (null != result && result.IsSuccessful && null != result.Result && result.Result.ContainsKey ("result"))
					return result.Result ["result"];
			} catch (Exception e) {
				_logger.Log ("Error getting result: " + e.Message);
				_logger.Log (e.StackTrace);
			}
			return null;
		}

	}
}