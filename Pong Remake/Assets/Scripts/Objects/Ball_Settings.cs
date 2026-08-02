using UnityEngine;

public class Ball_Settings : MonoBehaviour
{
    float _speed = 6;
    float _originalVelocity;
    float _timeCount;
    int _xValue;
    int _yValue;    
    bool _respawnBall;

    Rigidbody2D _rig;
    Vector2 _originalPosition;

    void Awake()
    {
        _rig = GetComponent<Rigidbody2D>();
        _originalPosition = transform.position;
        _originalVelocity = _speed;
    }

    void Start()
        => BallMovement();

    void Update()
    {
        if (_respawnBall)
            RespawnBall();
    }

    void BallMovement()
    {
        if (UI_Controller.InstanceUIController.EndGame)
            _rig.velocity = Vector2.zero;

        else
        {
            _xValue = Random.Range(2, 4) == 2 ? 1 : -1;
            _yValue = Random.Range(-1, 2);
            _rig.velocity = new Vector2(_speed * _xValue, _speed * _yValue);
        }        
    } 
    
    void RespawnBall()
    {
        transform.position = _originalPosition;
        _speed = 0;
        _timeCount += Time.deltaTime;

        if (_timeCount >= 1f)
        {
            _speed = _originalVelocity;
            BallMovement();            
            _respawnBall = false;
            _timeCount = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.layer)
        {
            case 6:
                UI_Controller.InstanceUIController.Ponto_Player1++;
                _respawnBall = true;
                break;

            case 7:
                UI_Controller.InstanceUIController.Ponto_Player2++;
                _respawnBall = true;
                break;
        }
    }
}