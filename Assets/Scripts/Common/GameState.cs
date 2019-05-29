using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    public string currentPlace;

    public InventoryRepository Inventory { get; private set; }
    public GameProgressRepository GameProgress { get; private set; }
    public PuzzleAnswersRepository PuzzleAnswers { get; private set; }


    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        Instance = this;
        Inventory = InventoryRepositoryFactory.Create();
        GameProgress = GameProgressRepositoryFactory.Create();
        PuzzleAnswers = PuzzleAnswersRepositoryFactory.Create();

        GameProgress.UpdateSceneProgress("game", "new");

        Debug.Log($"Door code: {PuzzleAnswers.GetDoorCode()}");
        Debug.Log($"Map sequence code: {string.Join(",", PuzzleAnswers.GetMapSequence())}");
    }
}
