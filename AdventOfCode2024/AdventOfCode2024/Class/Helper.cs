namespace AdventOfCode2024.Class
{
	public class Helper
	{
		public static string GetFileContent(string filename)
		{
			try
			{
				using StreamReader reader = new StreamReader(filename);
				string text = reader.ReadToEnd();
				return text;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			throw new Exception();
		}
	}
}
