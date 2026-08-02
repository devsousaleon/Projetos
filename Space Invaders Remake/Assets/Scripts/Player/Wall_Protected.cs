using UnityEngine;

public class Wall_Protected : MonoBehaviour
{
    [SerializeField] int Life;

    void Update()
    {
        if (Life <= 0)
        {
            Life = 0;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
            Life -= 5;
        if (collision.gameObject.layer == 12)
            Life -= 2;
    }
}