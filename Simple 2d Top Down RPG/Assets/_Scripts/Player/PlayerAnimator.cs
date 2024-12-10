using UnityEngine;

namespace _Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayAnimation(PlayerAnimaton animation)
        {
            switch (animation)
            {
                case PlayerAnimation.Moving:
                    _animator.Play("Moving");
                    break;
                case PlayerAnimation.Idle:
                    _animator.Play("Idle");
                    break;
                default:
                    _animator.Play("Idle");
                    break;

            }
        }
    }

    public enum PlayerAnimation
    {
        Idle,
        Moving,
        Jump,
        Fall,
        Attack,
        Dead
    }
}
