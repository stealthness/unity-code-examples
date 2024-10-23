using UnityEngine;

namespace _Scripts
{
   public class GameManager : MonoBehaviour
   {

       private static GameManager _instance;

       private void Awake()
       {
           if (_instance == null)
           {
               _instance = this;
           }
           else
           {
               Destroy(this);
           }
       }


       private void Start()
       {
           Time.timeScale = 0.0f;
       }

       public void StartGame()
       {
           Time.timeScale = 1.0f;
           UIMenu.Instance.StartPanel.SetActive(false);
       }

       
       private void OnTriggerExit2D(Collider2D collision)
       {
           Debug.Log($"collision {collision.name} has left the area");
           if (collision.CompareTag("Pillar"))
           {
               Destroy(collision.gameObject);
           }
       }
   }
 
}

