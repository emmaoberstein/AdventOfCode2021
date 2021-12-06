using System;
using System.Linq;
					
public class Program
{	
	public static void Main()
	{
		var fish = input.Split(new string[] { "," }, StringSplitOptions.None).Select(i => Int32.Parse(i)).ToArray();
		var fishArray = new UInt64[9];
		
		for (int i = 0; i <= 8; i++) 
		{
			fishArray[i] = 0;
		}
		
		for (int i = 0; i < fish.Count(); i++) 
		{
			fishArray[fish[i]] = fishArray[fish[i]] + 1;
		}
		
		for (int i = 0; i < 256; i++) 
		{
			UInt64 newFishCount = fishArray[0];
			for (int j = 1; j <= 8; j++)
			{
				fishArray[j-1] = fishArray[j];
			}
			fishArray[8] = newFishCount;
			fishArray[6] = fishArray[6] + newFishCount;
		}
		
		UInt64 fishCount = 0;
		for (int i = 0; i <= 8; i++) 
		{
			fishCount += fishArray[i];
		}
		
		Console.WriteLine(fishCount);	
	}
	
	public static string input = "3,3,2,1,4,1,1,2,3,1,1,2,1,2,1,1,1,1,1,1,4,1,1,5,2,1,1,2,1,1,1,3,5,1,5,5,1,1,1,1,3,1,1,3,2,1,1,1,1,1,1,4,1,1,1,1,1,1,1,4,1,3,3,1,1,3,1,3,1,2,1,3,1,1,4,1,2,4,4,5,1,1,1,1,1,1,4,1,5,1,1,5,1,1,3,3,1,3,2,5,2,4,1,4,1,2,4,5,1,1,5,1,1,1,4,1,1,5,2,1,1,5,1,1,1,5,1,1,1,1,1,3,1,5,3,2,1,1,2,2,1,2,1,1,5,1,1,4,5,1,4,3,1,1,1,1,1,1,5,1,1,1,5,2,1,1,1,5,1,1,1,4,4,2,1,1,1,1,1,1,1,3,1,1,4,4,1,4,1,1,5,3,1,1,1,5,2,2,4,2,1,1,3,1,5,5,1,1,1,4,1,5,1,1,1,4,3,3,3,1,3,1,5,1,4,2,1,1,5,1,1,1,5,5,1,1,2,1,1,1,3,1,1,1,2,3,1,2,2,3,1,3,1,1,4,1,1,2,1,1,1,1,3,5,1,1,2,1,1,1,4,1,1,1,1,1,2,4,1,1,5,3,1,1,1,2,2,2,1,5,1,3,5,3,1,1,4,1,1,4";
}
