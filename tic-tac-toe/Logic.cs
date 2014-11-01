using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
	public enum PlayerValue
	{
		None,
		Cross,
		Circle
	}

	public class Logic
	{
		public PlayerValue[] gameState  { get; private set; }
		public PlayerValue   wonBy      { get; private set; }
		public PlayerValue   nextPlayer { get; private set; }
		public bool          tied       { get; private set; }

		public delegate void EndGameHandler(Logic l, PlayerValue who);
		public event EndGameHandler OnGameEnd;

		public Logic()
		{
			gameState = new PlayerValue[9];

			nextPlayer = PlayerValue.Cross;
			wonBy = PlayerValue.None;
			tied = false;

			for (int i = 0; i < gameState.Length; i++)
			{
				gameState[i] = PlayerValue.None;
			}
		}

		/// <summary>
		/// Changes the state of the game.
		/// 
		/// You check Logic.tied and Logic.wonBy after every change!
		/// </summary>
		/// <param name="box"></param>
		/// <returns></returns>
		public bool ChangeState(int box)
		{
			if (gameState[box] != PlayerValue.None ||
				wonBy != PlayerValue.None ||
				tied == true)
				return false;

			gameState[box] = nextPlayer;

			switch (nextPlayer)
			{
				case PlayerValue.Cross:
					nextPlayer = PlayerValue.Circle;
					break;
				case PlayerValue.Circle:
					nextPlayer = PlayerValue.Cross;
					break;
			}

			// Check ending conditions
			tied = checkTies();

			EndGameHandler endEvent = OnGameEnd;

			// Check victory conditions
			wonBy = checkVictoryConditions();

			if (endEvent != null && wonBy != PlayerValue.None)
				endEvent(this, wonBy);
			else if (endEvent != null && tied)
				endEvent(this, PlayerValue.None);

			return true;
		}

		private PlayerValue checkVictoryConditions()
		{
			int[][] VictoryConditions =
			{
				new int[] {0, 4, 8}, // ská, top left to bottom right \
				new int[] {2, 4, 6}, // ská, top right to bottom left /

				new int[] {0, 1, 2}, // lárétt efst                   -
				new int[] {3, 4, 5}, // lárétt miðja                  -
				new int[] {6, 7, 8}, // lárétt neðst                  -

				new int[] {0, 3, 6}, // lóðrétt vinstri               |
				new int[] {1, 4, 7}, // lóðrétt miðja                 |
				new int[] {2, 5, 8}, // lóðrétt hægri                 |
			};

			for (int i = 0; i < VictoryConditions.Length; i++)
			{
				if (gameState[VictoryConditions[i][0]] != PlayerValue.None &&
					gameState[VictoryConditions[i][0]] == gameState[VictoryConditions[i][1]] &&
					gameState[VictoryConditions[i][1]] == gameState[VictoryConditions[i][2]])
					return gameState[VictoryConditions[i][0]];
			}

			return PlayerValue.None;
		}

		private bool checkTies()
		{
			foreach (PlayerValue box in gameState)
				if (box == PlayerValue.None)
					return false;

			return true;
		}
	}
}
