using UnityEngine;

public class ObjectPathRepeater : MonoBehaviour
{

    public GameObject[] waypoints;

    [SerializeField] private int startAtIndexPosition = -1;
    [SerializeField] private int nextWayPoint = 0;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private bool _forward = true;
    [SerializeField] protected bool isDisableMovement = false;

    private readonly float TOL = 0.01f;
    private Vector3 _dir;

    void Start()
    {
        if (startAtIndexPosition < 0)
        {
            // stats at the current position and heads to nextWayPoint
            return;
        }

        
        if (_forward)
        {
            if (startAtIndexPosition < waypoints.Length - 1)
            {
                transform.position = waypoints[startAtIndexPosition].transform.position;
                nextWayPoint = startAtIndexPosition + 1; ;
            }
            else // if startAtIndexPosition is at the end then direction is reversed
            {
                transform.position = waypoints[startAtIndexPosition].transform.position;
                _forward = false;
                nextWayPoint = startAtIndexPosition - 1;
            }
        }
        else
        {
            if (startAtIndexPosition > 0)
            {
                transform.position = waypoints[startAtIndexPosition].transform.position;
                nextWayPoint = startAtIndexPosition - 1; ;
            }
            else // if startAtIndexPosition is at the start then direction is reversed
            {
                transform.position = waypoints[0].transform.position;
                _forward = true;
                nextWayPoint = 1;
            }
        }
    }



    // Update is called once per frame
    void Update()
    {

        if (isDisableMovement)
        {
            return;
        }


        if (Vector2.Distance(transform.position, waypoints[nextWayPoint].transform.position) < TOL)
        {
            if (_forward)
            {
                if (nextWayPoint == waypoints.Length - 1)
                {
                    nextWayPoint--;
                    _forward = false;
                }
                else
                {
                    nextWayPoint++;
                }
            }
            else
            {

                if (nextWayPoint == 0)
                {
                    _forward = true;
                    nextWayPoint++;
                }
                else
                {
                    nextWayPoint--;
                }
            }
        }
        else
        {
            _dir = (waypoints[nextWayPoint].transform.position - transform.position).normalized;
            transform.Translate(_speed * Time.deltaTime * _dir);
        }
    }

    /// <summary>
    /// Diasble the the Object from moving
    /// </summary>
    public void OnDisableMovement()
    {
        isDisableMovement = true;
    }
}
