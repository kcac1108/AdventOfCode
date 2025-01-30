using System.Text.RegularExpressions;

namespace AdventOfCode.Day3
{
    internal class DayThree
    {
        public void Day3()
        {
            // Step 1: Read all lines from the input file into an array.
            string path = "C:\\Users\\KauaCavalheiro\\Documents\\Projects\\AdventOfCode\\AdventOfCode\\Day3\\input.txt";  // File path
            string[] docs = File.ReadAllLines(path);
            int mult = 0;
            string pattern = @"(?<control>(do(n\'t)?\(\))|(mul\((?<number1>[0-9]+),(?<number2>[0-9]+)\)))";
            bool disable = false;
            Regex regex = new Regex(pattern);

            // Step 3: Iterate through each line in the file.
            foreach (string doc in docs)
            {
                MatchCollection matches = regex.Matches(doc);
                foreach (Match match in matches)
                {
                    if (match.Groups["control"].Value == "don't()")
                        disable = true;
                    else if (match.Groups["control"].Value == "do()")
                        disable = false;
                    else if ((match.Groups["control"].Value.StartsWith("mul")) && (disable == false))
                        mult += int.Parse(match.Groups["number1"].Value) * int.Parse(match.Groups["number2"].Value);
                }
            }

            // Step 7: Output the final result.
            Console.WriteLine(mult);  // Print the final total multiplication sum
        }
    }
}
