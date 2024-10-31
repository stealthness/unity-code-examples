using UnityEngine;
namespace _Scripts.Enemy
{
    
    
    public class SlowEnemy : Enemy
    {
       

        protected override void Start()
        {
            base.Start();
            _enemyMovement.speed = 1f;
            InvokeRepeating(nameof(ChangeDirection), 0f, 0.3f);
        }
        
        private void ChangeDirection()
        {
            _enemyMovement.ChangeDirection();
        }
        

        
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(other.gameObject);
            }
        }
    }
    

}