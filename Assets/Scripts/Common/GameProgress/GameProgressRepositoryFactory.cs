using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressRepositoryFactory
{
    public static GameProgressRepository Create()
    {
#if UNITY_EDITOR
        return new GameProgressRepository(new InMemoryRepository<string>());
#else
        return new GameProgressRepository(new FileSystemRepository<string>("game-progress.dat"));
#endif
    }
}
