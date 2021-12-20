using System;
					
public class Program
{	
	public static void Main()
	{
		var values=0;		
		for (var xVelocity = 0; xVelocity <= 129; xVelocity++)
		{
			for (var yVelocity = -150; yVelocity <= 149; yVelocity++)
			{
				values+= hitsTarget(xVelocity,yVelocity);
			}
		}
		
        Console.WriteLine(values);
	}
	
	public static int hitsTarget(int xVelocity, int yVelocity)
	{
		var currX = 0;
		var currY = 0;
		
		while (currX <= 129 && currY >= -150)
		{
			currX += xVelocity;
			currY += yVelocity--;
			xVelocity = (xVelocity == 0) ? 0 : xVelocity-1;
			if (currX >= 81 && currX <= 129 && currY >= -150 && currY <= -108)
			{
				return 1;
			}
		}
		
		return 0;
	}
}
