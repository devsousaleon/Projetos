using UnityEngine;

public class Red_Enemy : MonoBehaviour
{
    float _timeCount;

    public Vector2 Position;

    public float Speed { get; set; } = 0.3f;

    public static Red_Enemy InstanceRedEnemy;

    void Awake()
    {
        InstanceRedEnemy = this;
        Position = transform.position;
    }

    void Update()
    {
        if (!GameController.InstanceGameController.EndGame)
        {
            _timeCount += Time.deltaTime;

            if (_timeCount >= 1f)
            {
                Position.x += Speed;
                transform.position = Position;
                _timeCount = 0f;
            }
        }  
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 || collision.CompareTag("Player"))
            Destroy(collision.gameObject);
    }
}