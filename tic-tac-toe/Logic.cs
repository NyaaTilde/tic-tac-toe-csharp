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
		public PlayerValue[] gameState { get; private set; }

		private PlayerValue lastMove = PlayerValue.None;

		public Logic()
		{
			gameState = new PlayerValue[9];

			for (int i = 0; i < gameState.Length; i++)
			{
				gameState[i] = PlayerValue.None;
			}
		}

		public bool ChangeState(int box)
		{
			if (gameState[box] != PlayerValue.None)
				return false;

			switch (lastMove)
			{
				case PlayerValue.None:
				case PlayerValue.Circle:
					lastMove = PlayerValue.Cross;
					break;
				case PlayerValue.Cross:
					lastMove = PlayerValue.Circle;
					break;
				default:
					break;
			}

			gameState[box] = lastMove;

			return true;
		}
	}
}
