using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _speed;

    Rigidbody2D _rig;

    public Vector2 Position { get; private set; }

    public static Player InstancePlayer;

    void Awake()
    {
        InstancePlayer = this;
        _rig = GetComponent<Rigidbody2D>();
        Position = transform.position;
    }
    void FixedUpdate()
    {
        if (!GameController.InstanceGameController.EndGame)
        {
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -4, 4), transform.position.y);
            float movement = Input.GetAxis("Horizontal");
            _rig.velocity = new Vector2(movement * _speed, _rig.velocity.y);
        }        
    }
}