using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    [SerializeField] int _damage;

    IDamageable _Idamageable;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _Idamageable = collision.gameObject.GetComponent<IDamageable>();
            _Idamageable.TakeDamage(_damage);
        }
    }
}