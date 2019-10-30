using System.Collections.Generic;
using System;

public class PuzzleAnswersRepository
{
    private static readonly string answersGenerated = "answersGenerated";
    private static readonly string doorAnswer = "doorAnswer";
    private static readonly string ticketCode = "ticketCode";
    private static readonly string mapAnswer = "mapAnswer";


    private IRepository<string> _puzzleAnswers;
    private CodeGenerator _doorCodeGenerator = new CodeGenerator(4);
    private SequenceGenerator _mapSequenceGenerator = new SequenceGenerator(12, 30, new int[] { 23 }, 4);

    public PuzzleAnswersRepository(IRepository<string> repository)
    {
        _puzzleAnswers = repository;
        GenerateAnswers();
    }

    public string GetDoorCode()
    {
        return _puzzleAnswers.GetElement(doorAnswer);
    }

    public List<string> GetMapSequence()
    {
        return new List<string>(_puzzleAnswers.GetElement(mapAnswer).Split(','));
    }

    public string GetTicketCode()
    {
        return _puzzleAnswers.GetElement(ticketCode);
    }

    private void GenerateAnswers()
    {
        if (_puzzleAnswers.GetElement(answersGenerated) != null) return;

        var doorCode = _doorCodeGenerator.GenerateCode();
        _puzzleAnswers.AddElement(doorAnswer, doorCode);

        var mapSequence = _mapSequenceGenerator.GenerateSequence();
        _puzzleAnswers.AddElement(mapAnswer, string.Join(",", mapSequence));

        var uuid = Guid.NewGuid().ToString().Split('-')[0].ToUpper();
        _puzzleAnswers.AddElement(ticketCode, uuid);

        _puzzleAnswers.AddElement(answersGenerated, "yes");
    }
}
