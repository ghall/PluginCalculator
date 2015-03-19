using System;

namespace PluginCalculator.Core.Providers.JsonHttpProvider
{
	public interface IJsonHttpProvider
	{
		ApiResult<T> Get<T>(string url);
		ApiResult<T> Post<T>(string url, string body);
		ApiResult<T> Delete<T>(string url);
		ApiResult<T> Put<T>(string url, string body);
	}
}

