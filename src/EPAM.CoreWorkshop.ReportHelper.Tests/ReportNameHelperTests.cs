using System.Diagnostics;
using System.Threading;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPAM.Core.ReportHelper.Tests
{
	[TestClass]
	public class ReportNameHelperTests
	{
		[AssemblyInitialize]
		public static void Init(TestContext context)
		{
			//Thread.Sleep(30 * 1000);
//#if DEBUG
//			while (!Debugger.IsAttached)
//			{
//				Thread.Sleep(1000); ;
//			}
//#endif
		}

		[TestMethod]
		//[DataRow("Hello: my world", '_', "Hello_ my world")]
		[DataRow("Hello my %world", '_', "Hello my %world")]
		[DataRow("Hello my /world", '_', "Hello my _world")]
		public void NormalizeFileNameTest(string name, char repl, string expected)
		{
			var result = ReportNameHelper.NormalizeFileName(name, repl);

			result.Should().BeEquivalentTo(expected);
		}
	}
}