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

			// Changing the state of a field that is set to PlayerValue.None is valid
			Assert.IsTrue(l.ChangeState(4));
			Assert.AreEqual(l.gameState[4], PlayerValue.Cross);

			Assert.IsTrue(l.ChangeState(0));
			Assert.AreEqual(l.gameState[0], PlayerValue.Circle);

			// Changing the state of a field that has a value other than PlayerValue.None is not valid
			Assert.IsFalse(l.ChangeState(4));
			Assert.IsFalse(l.ChangeState(0));
		}
	}
}
