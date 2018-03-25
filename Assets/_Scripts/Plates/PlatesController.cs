using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatesController : MonoBehaviour, IController
{
    [SerializeField] private InitialPlate _initialPlate;

    [SerializeField] private TargetPlate _targetPlate;

    [SerializeField] private List<Plate> _plates;

    private int _ringsCount;

    void Start()
    {
    }

    void Update()
    {
    }

    public void Init()
    {
        for (int i = 0, count = _plates.Count; i < count; ++i)
        {
            _plates[i].ActionRingPlaced = ActionRingPlacedHandler;
        }
    }

    public void Restart()
    {
        for (int i = 0, count = _plates.Count; i < count; ++i)
        {
            _plates[i].Restart();
        }
    }

    public void AddInitialRings(List<Ring> rings)
    {
        _ringsCount = rings.Count;

        for (int i = 0, count = rings.Count; i < count; ++i)
        {
            _initialPlate.AddRing(rings[i], true);
        }
    }

    public void EnablePlatesColliders()
    {
        for (int i = 0, count = _plates.Count; i < count; ++i)
        {
            _plates[i].EnableCollider();
        }
    }

    public void DisablePlatesColliders()
    {
        for (int i = 0, count = _plates.Count; i < count; ++i)
        {
            _plates[i].DisableCollider();
        }
    }

    private void ActionRingPlacedHandler(int ringCountInPlate, bool isTargetPlate)
    {
        GameController.Instance.InrementMoveCount();

        if (isTargetPlate && _ringsCount == ringCountInPlate)
        {
            GameController.Instance.GameOver();
        }

    }
}