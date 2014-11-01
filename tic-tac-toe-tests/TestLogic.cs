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

		[TestMethod()]
		public void LogicTestEndConditions()
		{
			Logic l = new Logic();

			// Top row
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(0));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(3));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(1));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(4));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(2));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.Cross);

			l = new Logic(); // new instance

			// Center row
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(3));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(6));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(4));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(7));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(5));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.Cross);

			l = new Logic(); // new instance

			// Bottom row
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(6));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(0));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(7));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(1));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(8));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.Cross);

			l = new Logic(); // new instance

			// Left column
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(1));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(0));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(2));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(3));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(4));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(6));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.Circle);

			l = new Logic(); // new instance

			// Center column
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(0));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(1));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(2));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(4));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(3));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(7));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.Circle);

			l = new Logic(); // new instance

			// Right column
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(0));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(2));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(1));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(5));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(3));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(8));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.Circle);

			l = new Logic(); // new instance

			// Top left to bottom right
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(0));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(2));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(4));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(5));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(8));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.Cross);

			l = new Logic(); // new instance

			// Right column
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(0));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(2));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(1));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(4));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(3));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(6));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.Circle);

			l = new Logic(); // new instance

			// Tie
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(0));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(4));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(8));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(7));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(1));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(2));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(6));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(3));
			Assert.IsFalse(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
			Assert.IsTrue(l.ChangeState(5));
			Assert.IsTrue(l.tied);
			Assert.AreEqual(l.wonBy, PlayerValue.None);
		}
	}
}
