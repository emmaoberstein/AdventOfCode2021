using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{	
	public static void Main()
	{
		var readings = input.Split(new string[] { "\r\n" }, StringSplitOptions.None);
		List<char> polymer = readings[0].ToCharArray().ToList();
		
		Dictionary<string, char> rules = new Dictionary<string, char>();
		int i = 2;
		while (i < readings.Length)
		{	
			var  split = readings[i].Split(new string[] { " -> " }, StringSplitOptions.None);
			rules[split[0]] = char.Parse(split[1]);	
			i++;
		}	
		
		int j = 0;
		while (j < 10)
		{	
			polymer = applyRules(polymer, rules);	
			j++;
		}
		
		var cCount = polymer.GroupBy(c => c).OrderBy(g => g.Count()).Select(c => new { Char = c.Key, Count = c.Count()});
		Console.WriteLine(cCount.Last().Count - cCount.First().Count);	
	}
	
	public static List<char> applyRules(List<char> polymer, Dictionary<string, char> rules)
	{
		List<char> newPolymer = new List<char>(); 
		
		int i = 0;
		while (i < polymer.Count() - 1)
		{
			newPolymer.Add(polymer[i]);
			string adjacent = new string(new char[] {polymer[i], polymer[i+1]});
			if (rules.ContainsKey(adjacent))
			{		
				newPolymer.Add(rules[adjacent]);
			}
			i++;
		}
		
		newPolymer.Add(polymer[i]);	
		return newPolymer;
	}
  
	private static string input = "SHPPPVOFPBFCHHBKBNCV\r\n\r\nHK -> C\r\nSP -> H\r\nVH -> K\r\nKS -> B\r\nBC -> S\r\nPS -> K\r\nPN -> S\r\nNC -> F\r\nCV -> B\r\nSH -> K\r\nSK -> H\r\nKK -> O\r\nHO -> V\r\nHP -> C\r\nHB -> S\r\nNB -> N\r\nHC -> K\r\nSB -> O\r\nSN -> C\r\nBP -> H\r\nFC -> V\r\nCF -> C\r\nFB -> F\r\nVP -> S\r\nPO -> N\r\nHN -> N\r\nBS -> O\r\nNF -> H\r\nBH -> O\r\nNK -> B\r\nKC -> B\r\nOS -> S\r\nBB -> S\r\nSV -> K\r\nCH -> B\r\nOB -> K\r\nFV -> B\r\nCP -> V\r\nFP -> C\r\nVC -> K\r\nFS -> S\r\nSS -> F\r\nVK -> C\r\nSF -> B\r\nVS -> B\r\nCC -> P\r\nSC -> S\r\nHS -> K\r\nCN -> C\r\nBN -> N\r\nBK -> B\r\nFN -> H\r\nOK -> S\r\nFO -> S\r\nVB -> C\r\nFH -> S\r\nKN -> K\r\nCK -> B\r\nKV -> P\r\nNP -> P\r\nCB -> N\r\nKB -> C\r\nFK -> K\r\nBO -> O\r\nOV -> B\r\nOC -> B\r\nNO -> F\r\nVF -> V\r\nVO -> B\r\nFF -> K\r\nPP -> O\r\nVV -> K\r\nPC -> N\r\nOF -> S\r\nPV -> P\r\nPB -> C\r\nKO -> V\r\nBF -> N\r\nOO -> K\r\nNV -> P\r\nPK -> V\r\nBV -> C\r\nHH -> K\r\nPH -> S\r\nOH -> B\r\nHF -> S\r\nNH -> H\r\nNN -> K\r\nKF -> H\r\nON -> N\r\nPF -> H\r\nCS -> H\r\nCO -> O\r\nSO -> K\r\nHV -> N\r\nNS -> N\r\nKP -> S\r\nOP -> N\r\nKH -> P\r\nVN -> H";
}
