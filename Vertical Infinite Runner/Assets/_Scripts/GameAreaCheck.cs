using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GameAreaCheck : MonoBehaviour
{
    public Transform leftLimit;
    public Transform rightLimit;
    private BoxCollider2D box;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        box.offset = new Vector3(0, leftLimit.position.y / 2, 0);
        box.size = new Vector2(rightLimit.position.x - leftLimit.position.x, leftLimit.position.y);
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
