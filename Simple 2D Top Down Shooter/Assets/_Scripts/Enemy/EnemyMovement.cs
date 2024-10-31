using _Scripts.Core;
using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyMovement : Movement2D
    {

        [SerializeField]private float _changeDirectionUpdateFequency = 0.5f;

        private void Start()
        {
            InvokeRepeating(nameof(ChangeDirection), 0f, _changeDirectionUpdateFequency);
        }

        internal void ChangeDirection()
        {
            MovementDirection = (EnemyManager.Instance.GetTarget() - transform.position).normalized;
        }
        

    }
}
