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

		private void logicTestGames(int[] moves, PlayerValue winner = PlayerValue.None)
		{
			Logic l = new Logic();
			l.OnGameEnd += gameEndEvent;

			foreach (int move in moves)
			{
				verifyEndState(l, false);
				Assert.IsTrue(l.ChangeState(move));
			}

			verifyEndState(l, true, winner);
		}

		[TestMethod()]
		public void LogicTestEndConditions()
		{
			// Top row
			logicTestGames(new int[] { 0, 3, 1, 4, 2 }, PlayerValue.Cross);
			logicTestGames(new int[] { 3, 0, 4, 1, 6, 2 }, PlayerValue.Circle);

			// Center row
			logicTestGames(new int[] { 3, 6, 4, 7, 5 }, PlayerValue.Cross);
			logicTestGames(new int[] { 0, 3, 1, 4, 6, 5 }, PlayerValue.Circle);

			// Bottom row
			logicTestGames(new int[] { 6, 0, 7, 1, 8 }, PlayerValue.Cross);
			logicTestGames(new int[] { 0, 6, 1, 7, 3, 8 }, PlayerValue.Circle);

			// Left column
			logicTestGames(new int[] { 0, 1, 3, 4, 6 }, PlayerValue.Cross);
			logicTestGames(new int[] { 1, 0, 2, 3, 4, 6 }, PlayerValue.Circle);

			// Center column
			logicTestGames(new int[] { 1, 2, 4, 5, 7 }, PlayerValue.Cross);
			logicTestGames(new int[] { 0, 1, 2, 4, 3, 7 }, PlayerValue.Circle);

			// Right column
			logicTestGames(new int[] { 2, 3, 5, 6, 8 }, PlayerValue.Cross);
			logicTestGames(new int[] { 0, 2, 1, 5, 3, 8 }, PlayerValue.Circle);

			// Top left to bottom right
			logicTestGames(new int[] { 0, 2, 4, 5, 8 }, PlayerValue.Cross);
			logicTestGames(new int[] { 1, 0, 2, 4, 3, 8 }, PlayerValue.Circle);

			// Top right to bottom left
			logicTestGames(new int[] { 2, 0, 4, 1, 6 }, PlayerValue.Cross);
			logicTestGames(new int[] { 0, 2, 1, 4, 3, 6 }, PlayerValue.Circle);

			// Tie
			logicTestGames(new int[] { 0, 4, 8, 7, 1, 2, 6, 3, 5 });

			// Bug - Win and tie in the same move
			logicTestGames(new int[] { 0, 1, 2, 5, 8, 7, 6, 3, 4 }, PlayerValue.Cross);
		}
	}
}
