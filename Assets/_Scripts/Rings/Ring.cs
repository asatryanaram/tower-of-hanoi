using UnityEngine;

public abstract class Ring : MonoBehaviour
{
    private int _size;
    public int Size
    {
        get { return _size; }
    }

    private Plate _currentPlate;
    public Plate CurrentPlate
    {
        get { return _currentPlate; }
        set { _currentPlate = value; }
    }

    private const float ZPosition = 10.0f;
    private const float InvokeTime = 0.1f;

    private GameController _gameController;
    private Vector3 _offset;
    private Vector3 _newPosition;
    private bool _isRingDraging;

    private Vector3 _prevPosition;

    
    protected Ring(int size)
    {
        _size = size;
    }

    void Awake()
    {
        _gameController = GameController.Instance;
    }

    void Start()
    {
        _prevPosition = transform.position;
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isRingDraging)
        {
            CancelInvoke("DragingStop");
            DragingStop();
            Plate plate = other.GetComponent<Plate>();

            if (null != plate)
            {
                if (!plate.AddRing(this))
                {
                    RemainedPrevPosition();
                }
            }
            _gameController.RingDroped();
        }
    }

    void OnMouseDown()
    {
        if (false == _currentPlate.IsCandDrag(this)) return;
        
        _prevPosition = transform.position;
        CancelInvoke("DragingStop");
        _isRingDraging = true;

        _offset = gameObject.transform.position -
                  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ZPosition));
    }

    private void OnMouseUp()
    {
        if (false == _isRingDraging) return;
        
        _gameController.RingDraged();
        CancelInvoke("DragingStop");
        Invoke("DragingStop", InvokeTime);
    }

    void OnMouseDrag()
    {
        if (false == _isRingDraging) return;
        
        _newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ZPosition);
        transform.position = Camera.main.ScreenToWorldPoint(_newPosition) + _offset;
    }

    private void DragingStop()
    {
        _isRingDraging = false;
        _gameController.RingDroped();
        RemainedPrevPosition();
    }

    private void RemainedPrevPosition()
    {
        transform.position = _prevPosition;
    }
}