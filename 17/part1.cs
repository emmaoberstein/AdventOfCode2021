using System;
					
public class Program
{	
	public static void Main()
	{
		var yTarget = -150;	
		int v = -yTarget-1;
		int y = 0;
		while (v >= 0)
		{
			y += v--;
		}
			
        	Console.WriteLine(y);
	}
}
