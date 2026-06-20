using UnityEngine;

public class BombAction_BomberGoblin : MonoBehaviour
{
    [SerializeField] float _velocityX;
    [SerializeField] float _velocityY;
    [SerializeField] int _damage;

    int _direction = 1;

    Rigidbody2D _rig;

    void Awake()
    {
        _rig = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(int direction)
    {
        _direction = direction;
    }

    void Start()
    {
        _rig.velocity = new Vector2(_velocityX * _direction, _velocityY);

        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            IDamageable damage = collision.GetComponent<IDamageable>();
            damage.TakeDamage(_damage);
            Destroy(gameObject);
        }
        if(collision.gameObject.layer == 3)
            Destroy(gameObject);
    }
}