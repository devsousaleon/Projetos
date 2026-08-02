using UnityEngine;

public class Blue_Enemy : MonoBehaviour
{
    float _timeCount;

    public Vector2 Position;

    public float _speed { get; set; } = 0.2f;

    public static Blue_Enemy InstanceBlueEnemy;

    void Awake()
    {
        InstanceBlueEnemy = this;
        Position = transform.position;
    }

    void Update()
    {
        if (!GameController.InstanceGameController.EndGame)
        {
            _timeCount += Time.deltaTime;

            if (_timeCount >= 1f)
            {
                Position.x += _speed;
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