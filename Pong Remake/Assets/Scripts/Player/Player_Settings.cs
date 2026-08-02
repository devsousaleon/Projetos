using UnityEngine;

public class Player_Settings : MonoBehaviour
{
    [SerializeField] float _speed;

    Rigidbody2D _rig;

    void Awake()
        => _rig = GetComponent<Rigidbody2D>();

    void FixedUpdate()
        => Movement();

    void Movement()
    {
        if (!UI_Controller.InstanceUIController.EndGame)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -3.2f, 3.2f));

            float movVertical = Input.GetAxis("Vertical");
            _rig.velocity = new Vector2(_rig.velocity.x, movVertical * _speed);
        }

        if (UI_Controller.InstanceUIController.EndGame)
        {
            _rig.velocity = Vector2.zero;
            transform.position = new Vector2(-7, 0);
        }
    }
}