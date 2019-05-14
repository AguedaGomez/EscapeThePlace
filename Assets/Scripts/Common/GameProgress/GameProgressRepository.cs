
public class GameProgressRepository
{
    private IRepository<string> _sceneProgresses;

    public GameProgressRepository(IRepository<string> repository)
    {
        _sceneProgresses = repository;
    }

    public void UpdateSceneProgress(string sceneName, string stage)
    {
        _sceneProgresses.AddElement(sceneName, stage);
    }

    public string GetSceneProgress(string sceneName)
    {
        var stage = _sceneProgresses.GetElement(sceneName);
        if (stage == null) return "1";
        return stage;
    }
}
