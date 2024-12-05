using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
    [Tooltip("Layers that will be checked for collisions")]
    public ContactFilter2D ContactFilter;
/*    [Tooltip("Layers that will be checked for collisions entered and exiting")]
    public ContactFilter2D ContactFilterTracking;*/

    protected BoxCollider2D _box;
    protected bool _isCollidable = true; 
    private readonly Collider2D[] _hits = new Collider2D[10];
/*    private readonly Collider2D[] _collidersEntered = new Collider2D[10];
    private readonly Collider2D[] _trackedHits = new Collider2D[10];*/


    protected virtual void Awake()
    {
        _box = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        if (!_isCollidable)
        {
            return;
        }

        // deal with contact
        _box.OverlapCollider(ContactFilter, _hits);

        for(int i  = 0; i < _hits.Length; i++)
        {
            if (_hits[i] == null)
            {
                continue;
            }
            OnCollide(_hits[i]);            
            _hits[i] = null;
        }

/*        _box.OverlapCollider(ContactFilterTracking, _trackedHits);
        for (int i = 0; i < _trackedHits.Length; i++)
        {
            if (_trackedHits[i] == null)
            {
                continue;
            }
            if (!_collidersEntered.Contains(_trackedHits[i]))
            {
                _collidersEntered[i] = _trackedHits[i];
                OnCollideEnter(_trackedHits[i]);
            }
            _trackedHits[i] = null;
        }  */ 
    }

    protected virtual void OnCollide(Collider2D collider)
    {
    }

/*    protected virtual void OnCollideEnter(Collider2D collision)
    {
        if (!_isCollidable || _collidersEntered.Length == 0)
        {
            return;
        }
    }

    protected virtual void OnCollideExit(Collider2D collision)
    {
        if (!_isCollidable || _collidersEntered.Length == 0)
        {
            return;
        }
    }*/
}
