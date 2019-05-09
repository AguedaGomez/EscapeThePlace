using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAnswersRepository : MonoBehaviour
{
    private static readonly string answersGenerated = "answersGenerated";
    private static readonly string doorAnswer = "doorAnswer";
    private static readonly string mapAnswer = "mapAnswer";

    IRepository<string> _puzzleAnswers;

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

    private void GenerateAnswers()
    {
        if (_puzzleAnswers.GetElement(answersGenerated) != null) return;
        // Code generator
        // Sequence generator
        _puzzleAnswers.AddElement(answersGenerated, "yes");
    }
}
