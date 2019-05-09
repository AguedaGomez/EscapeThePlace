using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressRepository
{
    private IRepository<int> _sceneProgresses;

    public GameProgressRepository(IRepository<int> repository)
    {
        _sceneProgresses = repository;
    }

    public void UpdateSceneProgress(string sceneName, int stage)
    {
        _sceneProgresses.AddElement(sceneName, stage);
    }

    public int GetSceneProgress(string sceneName)
    {
        var stage = _sceneProgresses.GetElement(sceneName);
        if (stage == 0) return 1;
        return stage;
    }
}
