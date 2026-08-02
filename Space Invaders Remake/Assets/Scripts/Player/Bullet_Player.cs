using UnityEngine;

public class Bullet_Player : MonoBehaviour
{
    [SerializeField] int _speed;

    Rigidbody2D _rig;
    
    void Awake()
        => _rig = GetComponent<Rigidbody2D>();

    void Start()
    {
        if (!GameController.InstanceGameController.EndGame)
        {
            _rig.velocity = new Vector2(_rig.velocity.x, _speed);
            Destroy(gameObject, 3f);
        }            
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.layer)
        {
            case 6:
                Destroy(gameObject);                
                break;
            case 7:
            case 8:
            case 9:
                Destroy(collision.gameObject);
                Destroy(gameObject);
                GameController.InstanceGameController.EnemyAmount--;
                break;
        }
    }
}