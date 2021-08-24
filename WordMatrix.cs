using System.Collections.Generic;
using System.Linq;

public class WordMatrix
{
    private string[] _columns;
    private string[] _rows;
    private int _wordSize;
    public WordMatrix(IEnumerable<string> matrix, int wordSize)
    {
        _columns = new string[wordSize];
        _rows = new string[wordSize];
        _wordSize = wordSize;
        FillColumns(matrix);
        FillRows(matrix);
    }


    public IEnumerable<string> FindTopTenResults(IEnumerable<string> wordStream)
    {
        Dictionary<string, int> results = new Dictionary<string, int>();
        foreach (string word in wordStream)
        {
            results.Add(word, 0);
            results[word] = CountWord(word, _columns) + CountWord(word, _rows);
        }

        return GetTopTenFoundWords(results);
    }

    private void FillColumns(IEnumerable<string> matrix)
    {
        int index = 0;
        foreach (string s in matrix)
        {
            _columns[index] = _columns[index] + s;
            index++;

            if (index == this._wordSize)
                index = 0;
        }
    }

    private void FillRows(IEnumerable<string> matrix)
    {
        int index = 0;
        int iteration = 0;
        foreach (string s in matrix)
        {
            _rows[index] = _rows[index] + s;

            iteration++;

            if (iteration == this._wordSize)
            {
                index++;
                iteration = 0;
            }
        }
    }

    private int CountWord(string word, string[] stream)
    {
        int count = 0;
        foreach (string s in stream)
        {
            if (s.Contains(word))
                count++;
        }
        return count;
    }

    private IEnumerable<string> GetTopTenFoundWords(Dictionary<string, int> results)
    {
        return results
            .Where(d => d.Value > 0)
            .OrderByDescending(d => d.Value)
            .Take(10)
            .Select(r => r.Key);
    }
}
