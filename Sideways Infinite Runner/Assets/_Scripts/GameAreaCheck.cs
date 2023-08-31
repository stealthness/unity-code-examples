using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GameAreaCheck : MonoBehaviour
{
    public Transform topLeftLimit;
    public Transform boxCenter;
    private BoxCollider2D box;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        box.offset = boxCenter.position;
        box.size = 2 * new Vector2(topLeftLimit.position.x - boxCenter.position.x, topLeftLimit.position.x - topLeftLimit.position.y);
        box.isTrigger = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log($"collision {collision.name} has left the area");
        if (collision.CompareTag("Collidable"))
        {
            Destroy(collision.gameObject);
        }
    }
}
