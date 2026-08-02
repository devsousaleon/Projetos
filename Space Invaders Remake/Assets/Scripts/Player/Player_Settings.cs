using UnityEngine;

public class Player_Settings : MonoBehaviour
{
    float _timeCount;

    public int Health { get => _health; set => _health = value; }

    [SerializeField] int _speed;
    [SerializeField] int _health;

    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _bulletSpawn;
    
    Rigidbody2D _rig;

    public static Player_Settings InstancePlayer;

    void Awake()
    {
        InstancePlayer = this;
        _rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Death();
        Shoot();
    }

    void FixedUpdate()
        => Movement();

    void Movement()
    {
        if (!GameController.InstanceGameController.EndGame)
        {
            float movement = Input.GetAxis("Horizontal");
            _rig.velocity = new Vector2(movement * _speed, _rig.velocity.y);
        }
    }

    void Shoot()
    {
        if (!GameController.InstanceGameController.EndGame)
        {
            _timeCount += Time.deltaTime;
            if (_timeCount >= 1f && Input.GetMouseButtonDown(0))
            {
                Instantiate(_bullet, _bulletSpawn.position, _bulletSpawn.rotation);
                _timeCount = 0f;
            }
        }
    }

    void Death()
    {
        if (Health <= 0)
        {
            Health = 0;
            GameController.InstanceGameController.ShowEndGame();
            Destroy(gameObject);            
        }
    }
}