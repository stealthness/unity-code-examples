using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
    [Tooltip("Layers that will be checked for collisions")]
    public ContactFilter2D contactFilter;

    protected BoxCollider2D box;
    private Collider2D[] hits = new Collider2D[10];


    protected virtual void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        box.OverlapCollider(contactFilter, hits);
        for(int i  = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }
            //Debug.Log($"{i}: {hits[i].name}");
            OnCollide(hits[i]);
            
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D collider)
    {
    }
}
