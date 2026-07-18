using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField] Transform _frontLine;
    [SerializeField] Transform _backLine;    
    [SerializeField] LayerMask _playerLayer;

    [SerializeField] float _distanceLine;
    [SerializeField] float _velocity;
    
    int _direction;
    bool _seeingPlayer = false;

    Rigidbody2D _rig;
    SpriteRenderer _spriteRenderer;
    SlimeAnimation _slimeAnimation;

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _slimeAnimation = GetComponent<SlimeAnimation>();
    }

    void FixedUpdate()
    {
        if (_seeingPlayer)
            _rig.velocity = new Vector2(_velocity * _direction, _rig.velocity.y);

        Movement();
    }

    void Movement()
    {
        RaycastHit2D raycastFrontLine = Physics2D.Raycast(_frontLine.position, Vector2.left, _distanceLine, _playerLayer);
        RaycastHit2D raycastBackLine = Physics2D.Raycast(_backLine.position, Vector2.right, _distanceLine, _playerLayer);

        if (raycastFrontLine.collider == null && raycastBackLine.collider == null)
        {
            _seeingPlayer = false;
            _slimeAnimation.AnimationIdle();
            return;
        }

        Rotaciona(raycastFrontLine, raycastBackLine);
    }


    void Rotaciona(RaycastHit2D rayFront, RaycastHit2D rayBack)
    {
        _seeingPlayer = true;
        _slimeAnimation.AnimationMove();

        if (rayFront.collider != null)
        {
            _spriteRenderer.flipX = false;
            _direction = -1;
        }
        else if (rayBack.collider != null)
        {
            _spriteRenderer.flipX = true;
            _direction = 1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_frontLine.position, Vector2.left * _distanceLine);
        Gizmos.DrawRay(_backLine.position, Vector2.right * _distanceLine);
    }
}