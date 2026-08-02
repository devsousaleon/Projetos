using UnityEngine;

public class Yellow_Enemy : MonoBehaviour
{
    float _timeCount;

    public Vector2 _positionInScene;

    public float Speed { get; set; } = 0.1f;

    public static Yellow_Enemy InstanceYellowEnemy;
    void Awake()
    {
        InstanceYellowEnemy = this;
        _positionInScene = transform.position;
    }

    void Update()
    {
        if (!GameController.InstanceGameController.EndGame)
        {
            _timeCount += Time.deltaTime;

            if (_timeCount >= 1f)
            {
                _positionInScene.x += Speed;
                transform.position = _positionInScene;
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