using UnityEngine;
using UnityEngine.UI;

public abstract class Popup : MonoBehaviour
{
    [SerializeField] private GameObject _popup;
    
    void Start()
    {
    }

    void Update()
    {
    }

    public bool IsShown()
    {
        return _popup.activeSelf;
    }
    
    public void Show()
    {
        _popup.SetActive(true);
    }

    public void Hide()
    {
        _popup.SetActive(false);
    }
    
    public void ButtonRestartPressedHandler()
    {
        GameController.Instance.Restart();
    }
    
    public void ButtonQuitPressedHandler()
    {
        GameController.Instance.ExitGame();
    }
}