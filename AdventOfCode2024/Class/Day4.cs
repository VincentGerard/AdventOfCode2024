using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Class
{
	public static class Day4
	{
		public static int GetPart1Result(string filename)
		{
			string text = Helper.GetFileContent(filename);
			int nbrRows = text.Split("\r\n").Count();
			int nbrColumns = text.Split("\r\n").First().Length;
			int nbrXmas = 0;
			text = text.Replace("\r\n", "");

			char[,] array = new char[nbrRows, nbrColumns];

			for(int row = 0; row < nbrRows; row++)
			{
				for(int column = 0; column < nbrColumns; column++)
				{
					array[row, column] = text[(row * nbrColumns) + column];
				}
			}

			for (int row = 0; row < nbrRows; row++)
			{
				for (int column = 0; column < nbrColumns; column++)
				{
					if(array[row,column] == 'X')
					{
						//Right
						if (column + 3 < nbrColumns && array[row, column + 1] == 'M' && array[row, column + 2] == 'A' && array[row, column + 3] == 'S')
							nbrXmas++;
						//Left
						if (column - 3 >= 0 && array[row, column - 1] == 'M' && array[row, column - 2] == 'A' && array[row, column - 3] == 'S')
							nbrXmas++;
						//Up
						if (row - 3 >= 0 && array[row - 1, column] == 'M' && array[row - 2, column] == 'A' && array[row - 3, column] == 'S')
							nbrXmas++;
						//Down
						if (row + 3 < nbrRows && array[row + 1, column] == 'M' && array[row + 2, column] == 'A' && array[row + 3, column] == 'S')
							nbrXmas++;
						//DownRight
						if (row + 3 < nbrRows && column + 3 < nbrColumns && array[row + 1, column + 1] == 'M' && array[row + 2, column + 2] == 'A' && array[row + 3, column + 3] == 'S')
							nbrXmas++;
						//DownLeft
						if (row + 3 < nbrRows && column - 3 >= 0 && array[row + 1, column - 1] == 'M' && array[row + 2, column - 2] == 'A' && array[row + 3, column - 3] == 'S')
							nbrXmas++;
						//UpRight
						if (row - 3 >= 0 && column + 3 < nbrColumns && array[row - 1, column + 1] == 'M' && array[row - 2, column + 2] == 'A' && array[row - 3, column + 3] == 'S')
							nbrXmas++;
						//UpLeft
						if (row - 3 >= 0 && column - 3 >= 0 && array[row - 1, column - 1] == 'M' && array[row - 2, column - 2] == 'A' && array[row - 3, column - 3] == 'S')
							nbrXmas++;
					}
				}
			}
			return nbrXmas;
		}
		
		public static int GetPart2Result(string filename)
		{
			return 0;
		}
	}
}
