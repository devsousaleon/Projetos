using UnityEngine;

public class MushroomMovement : MonoBehaviour
{
    [SerializeField] int _velocity;
    [SerializeField] float _radiusWall;

    public float Direction { get; set; } = 1;
    public bool PlayerInFront { get; set; } = false;

    bool _facingRight = true;

    [SerializeField] Transform _detectWall;
    [SerializeField] LayerMask _layerWall;

    Rigidbody2D _rig;
    MushroomAttack _mushroomAttack;
    MushroomHealth _mushroomHealth;

    public static MushroomMovement MushoroomMove;

    void Awake()
    {
        MushoroomMove = this;
        _mushroomAttack = GetComponent<MushroomAttack>();
        _mushroomHealth = GetComponent<MushroomHealth>();
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

        _mushroomAttack.RaycastDirection = _facingRight == true ? Vector2.left : Vector2.right;
        transform.localScale = scale;
    }

    void Movement()
    {
        if (!PlayerInFront && !_mushroomHealth.IsDead)
            _rig.velocity = new Vector2(_velocity * Direction, _rig.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_detectWall.position, _radiusWall);
    }
}