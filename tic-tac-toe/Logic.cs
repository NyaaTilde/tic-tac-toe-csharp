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

		public Logic()
		{
			gameState = new PlayerValue[9];

			for (int i = 0; i < gameState.Length; i++)
			{
				gameState[i] = PlayerValue.None;
			}
		}
	}
}
