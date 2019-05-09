using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressRepositoryFactory
{
    public static GameProgressRepository Create()
    {
#if UNITY_EDITOR
        return new GameProgressRepository(new InMemoryRepository<int>());
#else
        return new GameProgressRepository(new FileSystemRepository<int>("game-progress.dat"));
#endif
    }
}
