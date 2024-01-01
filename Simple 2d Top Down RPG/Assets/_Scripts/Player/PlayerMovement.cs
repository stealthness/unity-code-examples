using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : Movement
{
    [SerializeField] private string[] _layers = new string[] { "Blocking" };
    private Animator _animator;
    private PlayerController _playerController;
    private RaycastHit2D _hit;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

     private void Start()
    {
        _speed = 5f;
    }

    private void Update()
    {
        Vector2 dir = _playerController.MoveDir;
        if (_playerController.MoveDir != Vector2.zero && CheckMove(dir)) 
        {
            _animator.SetBool("IsMoving", true);
            MoveDir(dir);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }

    /// <summary>
    /// Checks collision using box cast
    /// Note: remember to change settings of Physics2D to uncheck "queires start in collider"
    /// </summary>
    /// <returns></returns>
    private bool CheckMove(Vector2 dir)
    {
        int layerMasks = LayerMask.GetMask(_layers);
        if (Mathf.Abs(dir.y) > 0)
        {
            _hit = Physics2D.BoxCast(transform.position, ((BoxCollider2D)_box).size, 0, new Vector2(0, dir.y), Mathf.Abs(dir.y * Time.deltaTime * _speed), layerMasks);
            if (_hit.collider != null)
            {
                return false;
            }
        }
        
        if (Mathf.Abs(dir.x) > 0)
        {
            _hit = Physics2D.BoxCast(transform.position, ((BoxCollider2D)_box).size, 0, new Vector2(dir.x, 0), Mathf.Abs(dir.x * Time.deltaTime * _speed), layerMasks);
            if (_hit.collider != null)
            {
                return false;
            }
        }

        
        return true;
    }
}
