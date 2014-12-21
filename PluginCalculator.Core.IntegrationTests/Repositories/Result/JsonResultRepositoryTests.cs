using System;
using NUnit.Framework;
using PluginCalculator.Core.Repositories.Result;
using PluginCalculator.Core.NativePlugins;
using Moq;

namespace PluginCalculator.Core.IntegrationTests.Repositories.Result
{
	[TestFixture]
	public class JsonResultRepositoryTests : BaseResultRepositoryTests
	{
		private Mock<ILogger> _logger;

		[SetUp]
		public void Setup() {
			_logger = new Mock<ILogger> ();
		}

		public override PluginCalculator.Core.Repositories.Result.IResultRepository GetTarget ()
		{
			return new JsonResultRepository (_logger.Object);
		}

	}
}

