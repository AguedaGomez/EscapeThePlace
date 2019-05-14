using System;
using System.Collections.Generic;

public class CodeGenerator
{
    private Random _random = new Random();
    private int _codeLength;

    public CodeGenerator(int codeLength)
    {
        _codeLength = codeLength;
    }

    public string GenerateCode()
    {
        var numbers = new List<int>();
        for (int i = 0; i < _codeLength; i++)
        {
            numbers.Add(NewNumber());
        }
        return string.Join("", numbers);
    }

    private int NewNumber()
    {
        return _random.Next(10);
    }
}
