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

        public void PlayAnimation(PlayerAnimation animationState)
        {
            switch (animationState)
            {
                case PlayerAnimation.Moving:
                    _animator.Play("Moving");
                    break;
                case PlayerAnimation.Idle:
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
