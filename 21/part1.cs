using System;
					
public class Program
{	
	public class Player 
	{
		public int score = 0;
		public int position;
	}
	
	public static void Main()
	{	
		var player1 = new Player() { position = 7 };
		var player2 = new Player() { position = 10 };
		
		int roll = 1;
		double totalRolls = 0;
		
		while (player1.score < 1000 && player2.score < 1000)
		{
			var currentPlayer = (totalRolls % 2 == 0) ? player1 : player2;
			var roll1 = (roll - 1) % 100 + 1;
			var roll2 = (roll) % 100 + 1;	
			var roll3 = (roll + 1) % 100 + 1;
			
			currentPlayer.position = (currentPlayer.position + roll1 + roll2 + roll3 - 1) % 10 + 1;
			currentPlayer.score += currentPlayer.position;
			
			roll = (roll + 2) % 100 + 1;
			totalRolls +=3;		
		}
		
        Console.WriteLine(player2.score*totalRolls);
	}
}
