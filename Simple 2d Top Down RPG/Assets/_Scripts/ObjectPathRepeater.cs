using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPathRepeater : MonoBehaviour
{

    public GameObject[] waypoints;

    [SerializeField] private float _speed = 1f;
    [SerializeField] private bool _forward = true;
    public int nextWayPoint;

    private readonly float TOL = 0.01f;
    private Vector3 _dir;

    void Start()
    {
        if (_forward)
        {
            transform.position = waypoints[0].transform.position;
            nextWayPoint = 1;
        }
        else
        {

            transform.position = waypoints[waypoints.Length - 1].transform.position;
            nextWayPoint = waypoints.Length - 2;
        }

    }



    // Update is called once per frame
    void Update()
    {

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
     
}
