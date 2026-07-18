using UnityEngine;

public class WormMovement : MonoBehaviour
{
    [SerializeField] float _velocity;
    [SerializeField] float _radiusWall;

    public float Direction { get; set; } = 1;
    public bool PlayerInFront { get; set; } = false;

    bool _facingRight = true;

    [SerializeField] Transform _detectWall;
    [SerializeField] LayerMask _layerWall;

    Rigidbody2D _rig;
    WormHealth _wormHealth;

    public static WormMovement WormMove;

    void Awake()
    {
        WormMove = this;
        _wormHealth = GetComponent<WormHealth>();
    }

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckWall();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void CheckWall()
    {
        Collider2D collider = Physics2D.OverlapCircle(_detectWall.position, _radiusWall, _layerWall);

        if (collider != null)
        {
            Flip();
        }
    }

    public void Flip()
    {
        _facingRight = !_facingRight;
        Direction = -Direction;

        Vector3 scale = transform.localScale;
        scale.x *= -1;

        transform.localScale = scale;
    }

    void Movement()
    {
        if (!PlayerInFront && !_wormHealth.IsDead)
            _rig.velocity = new Vector2(_velocity * Direction, _rig.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_detectWall.position, _radiusWall);
    }
}