using System.Xml;

namespace AdventOfCode2024.Class
{
	public static class Day6
	{
		/// <summary>
		/// First row and column needs to be lower then second row and column
		/// <param name="array"></param>
		/// <param name="firstRow"></param>
		/// <param name="firstColumn"></param>
		/// <param name="secondRow"></param>
		/// <param name="secondColumn"></param>
		/// <param name="direction"></param>
		/// <returns></returns>
		private static bool IsEmptyBetweenTwoPoints(char[,] array, int firstRow, int firstColumn, int secondRow, int secondColumn, char direction)
		{
			//Horizontal
			if(direction == 'h')
			{
				for(int i = firstColumn; i < secondColumn; i++)
				{
					if (array[firstRow,i] == '#') 
					{
						return false;
					}
				}
				return true;
			}
			//Vertical
			else if(direction == 'v')
			{
				for(int i = firstRow; i < secondRow; i++)
				{
					if(array[i, firstColumn] == '#')
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		private static int AreTurningPointsFormingLoop(List<(int row, int column)> turningPoints, int row, int column, char[,] array)
		{
			if(turningPoints.Count >= 3)
			{
				if(array[row, column] == '^')
				{
					foreach ((int row, int column) turningPoint in turningPoints.Where(t => t.row == row && t.column > column))
					{
						if (IsEmptyBetweenTwoPoints(array, row, column, turningPoint.row, turningPoint.column, 'h')) 
							return 1;
					}
				}
				else if(array[row, column] == 'v')
				{
					foreach ((int row, int column) turningPoint in turningPoints.Where(t => t.row == row && t.column < column))
					{
						if (IsEmptyBetweenTwoPoints(array, turningPoint.row, turningPoint.column, row, column, 'h'))
							return 1;
					}
				}
				else if(array[row, column] == '>')
				{
					foreach ((int row, int column) turningPoint in turningPoints.Where(t => t.column == column && t.row > row))
					{
						if (IsEmptyBetweenTwoPoints(array, row, column, turningPoint.row, turningPoint.column, 'v'))
							return 1;
					}
				}
				else if(array[row, column] == '<')
				{
					foreach ((int row, int column) turningPoint in turningPoints.Where(t => t.column == column && t.row < row))
					{
						if (IsEmptyBetweenTwoPoints(array, turningPoint.row, turningPoint.column, row, column, 'v'))
							return 1;
					}
				}
			}
			return 0;
		}

		public static int GetPart1Result(string filename)
		{
			string text = Helper.GetFileContent(filename);

			int nbrRows = text.Split("\r\n").Count();
			int nbrColumns = text.Split("\r\n").First().Length;
			char[,] array = new char[nbrRows, nbrColumns];
			text = text.Replace("\r\n", "");
			int startIndex = text.IndexOf("^");
			int row = startIndex / nbrColumns;
			int column = startIndex % nbrColumns;
			int nbrX = 0;

			for (int curRow = 0; curRow < nbrRows; curRow++)
			{
				for (int curColumn = 0; curColumn < nbrColumns; curColumn++)
				{
					array[curRow, curColumn] = text[(curRow * nbrColumns) + curColumn];
				}
			}

			while (true)
			{
				int oldRow = row;
				int oldColumn = column;
				//If the gaurd is in the outer layer, we can stop
				if (row + 1 == nbrRows || row - 1 < 0 || column + 1 == nbrColumns || column - 1 < 0)
				{
					break;
				}

				//If need to turn
				if(array[row,column] == '^' && array[row - 1,column] == '#')
				{
					column++;
					array[row, column] = '>';
				}
				else if(array[row,column] == '>' && array[row, column + 1] == '#')
				{
					row++;
					array[row, column] = 'v';
				}
				else if(array[row,column] == 'v' && array[row + 1, column] == '#')
				{
					column--;
					array[row, column] = '<';
				}
				else if(array[row,column] == '<' && array[row, column - 1] == '#')
				{
					row--;
					array[row, column] = '^';
				}
				else if(array[row,column] == '^')
				{
					row--;
					array[row, column] = '^';
				}
				else if(array[row,column] == '>')
				{
					column++;
					array[row , column] = '>';
				}
				else if(array[row,column] == 'v')
				{
					row++;
					array[row, column] = 'v';
				}
				else if(array[row,column] == '<')
				{
					column--;
					array[row, column] = '<';
				}

				array[oldRow, oldColumn] = 'X';
			}

			for (int curRow = 0; curRow < nbrRows; curRow++)
			{
				for (int curColumn = 0; curColumn < nbrColumns; curColumn++)
				{
					if (array[curRow, curColumn] == 'X')
						nbrX++;
				}
			}

			return nbrX + 1;
		}
		
		public static int GetPart2Result(string filename)
		{
			string text = Helper.GetFileContent(filename);

			int nbrRows = text.Split("\r\n").Count();
			int nbrColumns = text.Split("\r\n").First().Length;
			char[,] array = new char[nbrRows, nbrColumns];
			text = text.Replace("\r\n", "");
			int startIndex = text.IndexOf("^");
			int row = startIndex / nbrColumns;
			int column = startIndex % nbrColumns;
			int nbrObstacles = 0;
			List<(int row, int column)> turningPoints = new List<(int row, int column)>();

			for (int curRow = 0; curRow < nbrRows; curRow++)
			{
				for (int curColumn = 0; curColumn < nbrColumns; curColumn++)
				{
					array[curRow, curColumn] = text[(curRow * nbrColumns) + curColumn];
				}
			}

			while (true)
			{
				int oldRow = row;
				int oldColumn = column;

				if (row + 1 == nbrRows || row - 1 < 0 || column + 1 == nbrColumns || column - 1 < 0)
				{
					nbrObstacles += AreTurningPointsFormingLoop(turningPoints, oldRow, oldColumn, array);
					break;
				}

				if (array[row, column] == '^' && array[row - 1, column] == '#')
				{
					turningPoints.Add((row, column));
					column++;
					array[row, column] = '>';
				}
				else if (array[row, column] == '>' && array[row, column + 1] == '#')
				{
					turningPoints.Add((row, column));
					row++;
					array[row, column] = 'v';
				}
				else if (array[row, column] == 'v' && array[row + 1, column] == '#')
				{
					turningPoints.Add((row, column));
					column--;
					array[row, column] = '<';
				}
				else if (array[row, column] == '<' && array[row, column - 1] == '#')
				{
					turningPoints.Add((row, column));
					row--;
					array[row, column] = '^';
				}
				else if (array[row, column] == '^')
				{
					row--;
					array[row, column] = '^';
				}
				else if (array[row, column] == '>')
				{
					column++;
					array[row, column] = '>';
				}
				else if (array[row, column] == 'v')
				{
					row++;
					array[row, column] = 'v';
				}
				else if (array[row, column] == '<')
				{
					column--;
					array[row, column] = '<';
				}

				nbrObstacles += AreTurningPointsFormingLoop(turningPoints, oldRow, oldColumn, array);
			}

			return nbrObstacles;
		}
	}
}
