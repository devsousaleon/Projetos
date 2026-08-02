using UnityEngine;

public class Ball : MonoBehaviour
{
    int _directionInitialMoveX;
    bool BtnPressed;

    [SerializeField] int _speedMoveX;
    [SerializeField] int _speedMoveY;
    [SerializeField] int _valueHighScore;

    public int QuantityBlocks { get; set; } = 60;
    
    Rigidbody2D _rig;
    Vector2 _position;

    public static Ball InstanceBall;

    void Awake()
    {
        InstanceBall = this;
        _rig = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        BtnPressed = false;
        _directionInitialMoveX = Random.Range(1, 3) == 1 ? 1 : -1;        
        _position = transform.position;
    }

    void Update()
    {
        if (!BtnPressed && Input.GetKeyDown(KeyCode.UpArrow) && !GameController.InstanceGameController.EndGame)
        {
            _rig.velocity = new Vector2(_speedMoveX * _directionInitialMoveX, _speedMoveY);
            BtnPressed = true;
        }
    }

    void EndMap()
    {
        _directionInitialMoveX = Random.Range(1, 3) == 1 ? 1 : -1;
        transform.position = _position;
        Player.InstancePlayer.transform.position = Player.InstancePlayer.Position;
        BtnPressed = false;
        _rig.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Destroy(collision.gameObject);
            GameController.InstanceGameController.UpdateHighScore(_valueHighScore);
            QuantityBlocks--;            
        }

        if (collision.gameObject.layer == 7)
            EndMap();
    }
}