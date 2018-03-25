using UnityEngine;
using UnityEngine.UI;

public class MoveScore : MonoBehaviour
{
    [SerializeField] private Text _textMoveCount;
    
    void Start()
    {
    }

    void Update()
    {
    }

    public void UpdateMoveCount(int moveCount)
    {
        _textMoveCount.text = moveCount.ToString();
    }
}