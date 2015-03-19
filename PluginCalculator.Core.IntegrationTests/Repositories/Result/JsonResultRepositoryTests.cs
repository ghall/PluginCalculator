using System;
using NUnit.Framework;
using PluginCalculator.Core.Repositories.Result;
using PluginCalculator.Core.NativePlugins;
using Moq;
using PluginCalculator.Core.Providers.JsonHttpProvider;

namespace PluginCalculator.Core.IntegrationTests.Repositories.Result
{
	[TestFixture]
	public class JsonResultRepositoryTests : BaseResultRepositoryTests
	{
		private Mock<ILogger> _logger;
		private IJsonHttpProvider _jsonResultProvider;

		[SetUp]
		public void Setup() {
			_logger = new Mock<ILogger> ();
			_jsonResultProvider = new JsonHttpProvider (_logger.Object);
		}

		public override PluginCalculator.Core.Repositories.Result.IResultRepository GetTarget ()
		{
			return new JsonResultRepository (_logger.Object, _jsonResultProvider);
		}

	}
}

