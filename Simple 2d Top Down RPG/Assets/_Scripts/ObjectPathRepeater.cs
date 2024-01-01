using UnityEngine;

public class ObjectPathRepeater : MonoBehaviour
{

    public GameObject[] waypoints;

    [SerializeField] private int _startAtIndexPosition = -1;
    [SerializeField] private int _nextWayPoint = 0;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private bool _forward = true;
    [SerializeField] protected bool _isDisableMovement = false;

    private readonly float TOL = 0.01f;
    private Vector3 _dir;

    void Start()
    {
        if (_startAtIndexPosition < 0)
        {
            // stats at the current position and heads to nextWayPoint
            return;
        }

        
        if (_forward)
        {
            if (_startAtIndexPosition < waypoints.Length - 1)
            {
                transform.position = waypoints[_startAtIndexPosition].transform.position;
                _nextWayPoint = _startAtIndexPosition + 1; ;
            }
            else // if startAtIndexPosition is at the end then direction is reversed
            {
                transform.position = waypoints[_startAtIndexPosition].transform.position;
                _forward = false;
                _nextWayPoint = _startAtIndexPosition - 1;
            }
        }
        else
        {
            if (_startAtIndexPosition > 0)
            {
                transform.position = waypoints[_startAtIndexPosition].transform.position;
                _nextWayPoint = _startAtIndexPosition - 1; ;
            }
            else // if startAtIndexPosition is at the start then direction is reversed
            {
                transform.position = waypoints[0].transform.position;
                _forward = true;
                _nextWayPoint = 1;
            }
        }
    }



    // Update is called once per frame
    void Update()
    {

        if (_isDisableMovement)
        {
            return;
        }


        if (Vector2.Distance(transform.position, waypoints[_nextWayPoint].transform.position) < TOL)
        {
            if (_forward)
            {
                if (_nextWayPoint == waypoints.Length - 1)
                {
                    _nextWayPoint--;
                    _forward = false;
                }
                else
                {
                    _nextWayPoint++;
                }
            }
            else
            {

                if (_nextWayPoint == 0)
                {
                    _forward = true;
                    _nextWayPoint++;
                }
                else
                {
                    _nextWayPoint--;
                }
            }
        }
        else
        {
            _dir = (waypoints[_nextWayPoint].transform.position - transform.position).normalized;
            transform.Translate(_speed * Time.deltaTime * _dir);
        }
    }

    /// <summary>
    /// Diasble the the Object from moving
    /// </summary>
    public void OnDisableMovement()
    {
        _isDisableMovement = true;
    }
}
