using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
    [Tooltip("Layers that will be checked for collisions")]
    public ContactFilter2D ContactFilter;

    protected BoxCollider2D _box;
    private readonly Collider2D[] _hits = new Collider2D[10];


    protected virtual void Awake()
    {
        _box = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        _box.OverlapCollider(ContactFilter, _hits);
        for(int i  = 0; i < _hits.Length; i++)
        {
            if (_hits[i] == null)
            {
                continue;
            }
            //Debug.Log($"{i}: {hits[i].name}");
            OnCollide(_hits[i]);
            
            _hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D collider)
    {
    }
}
