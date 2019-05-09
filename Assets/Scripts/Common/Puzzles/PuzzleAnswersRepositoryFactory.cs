using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAnswersRepositoryFactory
{
    public static PuzzleAnswersRepository Create()
    {
#if UNITY_EDITOR
        return new PuzzleAnswersRepository(new InMemoryRepository<string>());
#else
        return new PuzzleAnswersRepository(new FileSystemRepository<string>("puzzle-answers.dat"));
#endif
    }
}
