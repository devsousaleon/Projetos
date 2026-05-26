using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform _groundDetectorPosition;
    [SerializeField] LayerMask _groundLayer;

    Rigidbody2D _rig;
    PlayerAnimation _playerAnim;
    PlayerHealth _playerHealth;

    [SerializeField] int _speed;
    [SerializeField] float _radiusGroundDetector;
    [SerializeField] float _jumpImpulse;

    public bool IsJumping { get; private set; }
    public float Movement { get; private set; }

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerHealth = GetComponent<PlayerHealth>();
    }
    void Update()
    {
        GroundDetector();
        ExecuteJump();        
    }
    void FixedUpdate()
    {
        ActionMovement();
    }
    
    void ActionMovement()
    {
        if (!_playerHealth.IsDead) 
        {
            Movement = Input.GetAxis("Horizontal");
            _rig.velocity = new Vector2(_speed * Movement, _rig.velocity.y);
            _playerAnim.AnimationMovement(IsJumping, Movement);

            transform.eulerAngles = (Movement > 0) ? new Vector2(0, 0) : (Movement < 0) ? new Vector2(0, 180) : transform.eulerAngles;
        }
    }

    void ExecuteJump()
    {
        if (!_playerHealth.IsDead)
        {
            if (!IsJumping && Input.GetButtonDown("Jump"))
            {
                _rig.AddForce(Vector2.up * _jumpImpulse, ForceMode2D.Impulse);
                IsJumping = true;
            }
        }
    }

    void GroundDetector()
    {
        Collider2D hit = Physics2D.OverlapCircle(_groundDetectorPosition.position, _radiusGroundDetector, _groundLayer);

        IsJumping = hit == null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundDetectorPosition.position, _radiusGroundDetector);
    }

}