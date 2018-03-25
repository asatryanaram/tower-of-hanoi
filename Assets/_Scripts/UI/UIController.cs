using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIController : MonoBehaviour, IController
{
    private MoveScore _moveScore;
    private Popup _pausePopup;
    private Popup _winPopup;

    void Awake()
    {
        _moveScore = FindObjectOfType<MoveScore>();
        _pausePopup = FindObjectOfType<PausePopup>();
        _winPopup = FindObjectOfType<WinPopup>();
    }

    void Start()
    {
    }

    void Update()
    {
    }

    public void Init()
    {
        _pausePopup.Hide();
    }

    public void Restart()
    {
        _pausePopup.Hide();
        _winPopup.Hide();
        UpdateMoveCount(0);
    }

    public void UpdateMoveCount(int count)
    {
        _moveScore.UpdateMoveCount(count);
    }

    public void ButtonMenuPressedHandler()
    {
        ShowPausePopup();
    }

    public void ShowPausePopup()
    {
        _pausePopup.Show();
    }

    public void HidePausePopup()
    {
        _pausePopup.Hide();
    }

    public void ShowWinPopup()
    {
        _winPopup.Show();
    }
}