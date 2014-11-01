using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using tic_tac_toe;

namespace tic_tac_toe_tests
{
	[TestClass]
	class TestLogic
	{
		[TestMethod]
		public void TestInstance()
		{
			Logic l = new Logic();

			Assert.IsInstanceOfType(l, typeof(Logic));
		}
	}
}
