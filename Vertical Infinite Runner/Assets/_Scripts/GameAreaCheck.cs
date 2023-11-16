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
        var y = leftLimit.position.y - (leftLimit.position.y - rightLimit.position.y) / 2;
        box.offset = new Vector3(0, y, 0);
        box.size = new Vector2(rightLimit.position.x - leftLimit.position.x, leftLimit.position.y - rightLimit.position.y);
        box.isTrigger = true;
    }

    /// <summary>
    /// Destroy Collidable objects that leave the game area
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Collidable"))
        {
            Destroy(collision.gameObject);
        }
    }
}
