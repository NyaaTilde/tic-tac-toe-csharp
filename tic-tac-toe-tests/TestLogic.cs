using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using tic_tac_toe;

namespace tic_tac_toe_Tests
{
	[TestClass()]
	public class TestLogic
	{
		[TestMethod()]
		public void LogicTest()
		{
			Logic l = new Logic();

			Assert.IsInstanceOfType(l, typeof(Logic));

			// Check that gameState is all set to PlayerValue.None
			for (int i = 0; i < l.gameState.Length; i++)
			{
				Assert.AreEqual(l.gameState[i], PlayerValue.None);
			}
		}
	}
}
