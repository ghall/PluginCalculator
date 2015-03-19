using System;

namespace PluginCalculator.Core.Providers.JsonHttpProvider
{
	public class ApiResult<T>
	{
		public ApiResult (string rawResult, T result)
		{
			RawResult = rawResult;
			Result = result;
		}

		public string RawResult { get; private set; }

		public T Result { get; private set; }

		public bool IsSuccessful {
			get { return null != RawResult; }
		}
	}
}