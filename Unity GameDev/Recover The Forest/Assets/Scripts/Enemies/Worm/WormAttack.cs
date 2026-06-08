using UnityEngine;

public class WormAttack : MonoBehaviour
{
    [SerializeField] int _damage;    

    IDamageable Idamageable;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Idamageable = collision.gameObject.GetComponent<IDamageable>();
            Idamageable.TakeDamage(_damage);
        }
    }
}