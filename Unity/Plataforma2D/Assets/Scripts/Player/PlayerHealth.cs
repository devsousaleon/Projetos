using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public bool IsDead { get; set; }

    [SerializeField] float _health;
    
    PlayerAnimation _playerAnim;

    public static PlayerHealth InstancePlayerHealth;

    void Awake()
    {
        InstancePlayerHealth = this;
        _playerAnim = GetComponent<PlayerAnimation>();
    }

    public void TakeDamage(int damage)
    {
        if (!IsDead)
        {
            _playerAnim.AnimationHit();
            _health -= damage;

            if (_health <= 0)
            {
                _health = 0;
                _playerAnim.AnimationDead();
            }
        }
    }
    public void EventAnimationDeath()
    {
        IsDead = true;
        gameObject.SetActive(false);        
    }
}