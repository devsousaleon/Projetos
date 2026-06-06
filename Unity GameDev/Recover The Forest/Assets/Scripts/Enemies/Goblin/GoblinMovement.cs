using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _timeToStop;
    [SerializeField] float _timeToMove;
    [SerializeField] float _wallColliderRadius;
    [SerializeField] float _rayBehindDistance;

    [SerializeField] Transform _wallCollider;
    [SerializeField] Transform _rayBehindPos;
    [SerializeField] LayerMask _wallLayer;
    [SerializeField] LayerMask _layerPlayer;

    public bool PlayerInFront { get; set; }

    float _timecountMovement;
    float _timecountIdle;
    int _direction = 1;

    Rigidbody2D _rig;
    Vector2 _rayBehindDirection = Vector2.left;
    GoblinAnimation _goblinAnimation;

    enum _stateMoveAction { Idle, Walking }
    _stateMoveAction _currentState;

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _currentState = _stateMoveAction.Walking;
        _goblinAnimation = GetComponent<GoblinAnimation>();
    }
    
    void Update()
    {
        ActionsState();
    }

    void FixedUpdate()
    {
        if (_currentState == _stateMoveAction.Walking && !PlayerInFront)
            _rig.velocity = new Vector2(_speed * _direction, _rig.velocity.y);

        RotateWallDetect();
        DetectPlayer();
    }

    void RotateWallDetect()
    {
        Collider2D hit = Physics2D.OverlapCircle(_wallCollider.position, _wallColliderRadius, _wallLayer);

        if (hit != null)
            Flip();
    }

    void DetectPlayer()
    {
        RaycastHit2D rayBehind = Physics2D.Raycast(_rayBehindPos.position, _rayBehindDirection, _rayBehindDistance, _layerPlayer);

        if (rayBehind.collider != null)
            Flip();
    }

    public void Flip()
    {
        _direction = -_direction;
        _rayBehindDirection = -_rayBehindDirection;

        Vector3 scale = transform.localScale;
        scale.x *= -1;

        transform.localScale = scale;
    }

    void ActionsState()
    {
        switch (_currentState)
        {
            case _stateMoveAction.Idle:
                ActionIdle();
                break;
            case _stateMoveAction.Walking:
                ActionMovement();
                break;
        }
    }

    void ActionMovement()
    {
        _goblinAnimation.AnimationRun();
        _timecountMovement += Time.deltaTime;

        if(_timecountMovement >= _timeToStop)
        {
            _timecountMovement = 0;
            _currentState = _stateMoveAction.Idle;
        }
    }
    
    void ActionIdle()
    {
        _goblinAnimation.AnimationIdle();
        _timecountIdle += Time.deltaTime;

        if (_timecountIdle >= _timeToMove)
        {
            _timecountIdle = 0;
            _currentState = _stateMoveAction.Walking;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_wallCollider.position, _wallColliderRadius);
        Gizmos.DrawRay(_rayBehindPos.position, _rayBehindDirection * _rayBehindDistance);
    }
}