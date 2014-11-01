using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using tic_tac_toe;

namespace tic_tac_toe_Tests
{
	[TestClass()]
	public class TestLogic
	{
		private int eventCalledTimes = 0;
		private PlayerValue endState = PlayerValue.None;

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

		private void gameEndEvent(Logic l, PlayerValue who)
		{
			eventCalledTimes += 1;
			endState = who;
		}

		private void verifyEndState(Logic l, bool eventShouldHaveBeenCalled, PlayerValue player = PlayerValue.None)
		{
			if (eventShouldHaveBeenCalled)
			{
				Assert.AreEqual(1, eventCalledTimes);
				Assert.AreEqual(player, endState);
			}
			else
			{
				Assert.AreEqual(0, eventCalledTimes);
			}

			// Reset
			eventCalledTimes = 0;
			endState = PlayerValue.None;
		}

		[TestMethod()]
		public void LogicTestEndConditions()
		{
			Logic l = new Logic();
			l.OnGameEnd += gameEndEvent;

			// Top row
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(0));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(3));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(1));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(4));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(2));
			verifyEndState(l, true, PlayerValue.Cross);

			l = new Logic(); // new instance
			l.OnGameEnd += gameEndEvent;

			// Center row
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(3));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(6));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(4));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(7));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(5));
			verifyEndState(l, true, PlayerValue.Cross);

			l = new Logic(); // new instance
			l.OnGameEnd += gameEndEvent;

			// Bottom row
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(6));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(0));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(7));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(1));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(8));
			verifyEndState(l, true, PlayerValue.Cross);

			l = new Logic(); // new instance
			l.OnGameEnd += gameEndEvent;

			// Left column
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(1));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(0));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(2));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(3));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(4));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(6));
			verifyEndState(l, true, PlayerValue.Circle);

			l = new Logic(); // new instance
			l.OnGameEnd += gameEndEvent;

			// Center column
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(0));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(1));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(2));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(4));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(3));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(7));
			verifyEndState(l, true, PlayerValue.Circle);

			l = new Logic(); // new instance
			l.OnGameEnd += gameEndEvent;

			// Right column
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(0));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(2));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(1));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(5));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(3));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(8));
			verifyEndState(l, true, PlayerValue.Circle);

			l = new Logic(); // new instance
			l.OnGameEnd += gameEndEvent;

			// Top left to bottom right
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(0));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(2));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(4));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(5));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(8));
			verifyEndState(l, true, PlayerValue.Cross);

			l = new Logic(); // new instance
			l.OnGameEnd += gameEndEvent;

			// Top right to bottom left
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(0));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(2));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(1));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(4));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(3));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(6));
			verifyEndState(l, true, PlayerValue.Circle);

			l = new Logic(); // new instance
			l.OnGameEnd += gameEndEvent;

			// Tie
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(0));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(4));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(8));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(7));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(1));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(2));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(6));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(3));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(5));
			verifyEndState(l, true, PlayerValue.None);

			l = new Logic(); // new instance
			l.OnGameEnd += gameEndEvent;

			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(0));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(1));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(2));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(5));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(8));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(7));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(6));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(3));
			verifyEndState(l, false);
			Assert.IsTrue(l.ChangeState(4));
			verifyEndState(l, true, PlayerValue.Cross);
		}
	}
}
