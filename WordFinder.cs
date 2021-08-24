using System;
using System.Collections.Generic;

public class WordFinder
{
	private WordMatrix _wordMatrix;
	public WordFinder(IEnumerable<string> matrix)
	{
		int sideLenght = CalculateSideLenght(matrix);
		this._wordMatrix = new WordMatrix(matrix, sideLenght);
	}
	public IEnumerable<string> Find(IEnumerable<string> wordStream)
	{
		return _wordMatrix.FindTopTenResults(wordStream);
	}
	private int CalculateSideLenght(IEnumerable<string> matrix)
	{
		int totalLength = 0;
		foreach (string s in matrix)
		{
			totalLength++;
		}

		double sideLenght = Math.Sqrt(totalLength);

		ValidateMatrixIsAPerfectSquare(sideLenght);

		return (int)sideLenght;
	}
	private void ValidateMatrixIsAPerfectSquare(double sideLenght)
	{
		if (sideLenght % 1 != 0)
			throw new Exception("Input matrix is not a perfect square.");
	}
}
