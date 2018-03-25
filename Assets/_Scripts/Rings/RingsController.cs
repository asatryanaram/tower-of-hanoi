using System.Collections.Generic;
using UnityEngine;

public class RingsController : MonoBehaviour, IController
{
    private List<Ring> _rings = new List<Ring>();
    public List<Ring> Rings
    {
        get { return _rings; }
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
        
    }
    
    public void InstantiateRings(GameObject[] ringsPrefabs)
    {
        for (int i = 0, count = ringsPrefabs.Length; i < count; ++i)
        {
            GameObject ringGameObject = Instantiate(ringsPrefabs[i]);
            Ring ring = ringGameObject.GetComponent<Ring>();
            _rings.Add(ring);
        }
        SortRings();
    }
    
    private void SortRings()
    {
        _rings.Sort((x,y)=> y.Size.CompareTo(x.Size));
    }
}