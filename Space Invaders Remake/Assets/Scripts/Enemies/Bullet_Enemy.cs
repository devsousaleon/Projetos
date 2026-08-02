using UnityEngine;

public class Bullet_Enemy : MonoBehaviour
{
    [SerializeField] float _speed;

    Rigidbody2D _rig;

    void Awake()
        => _rig = GetComponent<Rigidbody2D>();

    void Start()
        => Destroy(gameObject, 3f);

    void FixedUpdate()
        => _rig.velocity = new Vector2(_rig.velocity.x, -_speed);

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
            Destroy(gameObject);

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            Player_Settings.InstancePlayer.Health--;
        }
    }
}