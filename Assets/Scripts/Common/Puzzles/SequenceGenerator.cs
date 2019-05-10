using System;
using System.Collections.Generic;

public class SequenceGenerator
{
    private int _sequenceMin;
    private int _sequenceMax;
    private HashSet<int> _excludedElements;
    private int _sequenceLength;

    private Random _random = new Random();

    public SequenceGenerator(int sequenceMin, int sequenceMax, int[] excluded, int length)
    {
        _sequenceMin = sequenceMin;
        _sequenceMax = sequenceMax;
        _excludedElements = new HashSet<int>(excluded);
        _sequenceLength = length;
    }

    public List<int> GenerateSequence()
    {
        var numbers = new HashSet<int>();
        while (numbers.Count < _sequenceLength)
        {
            numbers.Add(NewNumber());
        }

        var numberSequence = new List<int>(numbers);
        numberSequence.Sort();
        return numberSequence;
    }

    public int NewNumber()
    {
        var number = _random.Next(_sequenceMin, _sequenceMax + 1);
        if (!_excludedElements.Contains(number)) return number;
        return NewNumber();
    }
}
