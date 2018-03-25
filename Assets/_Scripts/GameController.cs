using UnityEngine;

public class GameController : GenericSingletonClass<GameController>, IController
{
    [SerializeField] private GameObject[] _ringsPrefabs;

    private UIController _uiController;
    private PlatesController _platesController;
    private RingsController _ringsController;
    private int _moveCount;

    public override void Awake()
    {
        base.Awake();

        _uiController = FindObjectOfType<UIController>();
        _platesController = FindObjectOfType<PlatesController>();
        _ringsController = FindObjectOfType<RingsController>();
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
    }

    public void Init()
    {
        _ringsController.InstantiateRings(_ringsPrefabs);
        _platesController.Init();
        _ringsController.Init();        
        AddInitialRings();
        _moveCount = 0;
    }

    private void AddInitialRings()
    {
        _platesController.AddInitialRings(_ringsController.Rings);
    }

    public void Restart()
    {
        _platesController.Restart();
        _ringsController.Restart();
        _uiController.Restart();
        AddInitialRings();
        _moveCount = 0;
    }

    public void InrementMoveCount()
    {
        _uiController.UpdateMoveCount(++_moveCount);
    }

    public void RingDraged()
    {
        _platesController.EnablePlatesColliders();
    }

    public void RingDroped()
    {
        _platesController.DisablePlatesColliders();
    }

    public void GameOver()
    {
        _uiController.ShowWinPopup();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}