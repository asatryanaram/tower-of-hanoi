using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plate : MonoBehaviour, IController
{
    [SerializeField] private GameObject _container;
    
    private const float Height = 1.3f;
    
    private List<Ring> _placedRings = new List<Ring>();
    private BoxCollider2D _boxCollider2D;
    private bool _isTarget;
        
    public Action<int, bool> ActionRingPlaced;

    protected Plate(bool isTarget)
    {
        _isTarget = isTarget;
    }

    void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
    }

    void Update()
    {
    }

    public void Init()
    {
    }

    public void Restart()
    {
        _placedRings.Clear();
    }

    public void EnableCollider()
    {
        _boxCollider2D.enabled = true;
    }

    public void DisableCollider()
    {
        _boxCollider2D.enabled = false;
    }


    public bool AddRing(Ring ring, bool isInitial = false)
    {
        if (_placedRings.Count == 0)
        {
            PlaceRing(ring, isInitial);
            return true;
        }

        Ring lastRing = _placedRings[_placedRings.Count - 1];
        if (ring.Size < lastRing.Size)
        {
            PlaceRing(ring, isInitial);
            return true;
        }

        return false;
    }

    private void PlaceRing(Ring ring, bool isInitial)
    {
        Plate holderPlate = ring.CurrentPlate;

        if (null != holderPlate)
        {
            holderPlate.RemoveRing(ring);
        }

        _placedRings.Add(ring);
        ring.CurrentPlate = this;
        ring.transform.SetParent(_container.transform, false);
        ring.transform.localPosition = new Vector3(0, ((_placedRings.Count -1 ) * Height), 0);
        
        if (false == isInitial && null != ActionRingPlaced)
        {
            ActionRingPlaced(_placedRings.Count, _isTarget);
        }
    }

    private void RemoveRing(Ring ring)
    {
        _placedRings.Remove(ring);
    }

    public bool IsCandDrag(Ring ring)
    {
        int index = _placedRings.IndexOf(ring);

        return (-1 != index) && (index == _placedRings.Count - 1);
    }
}