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
            _health -= damage;
            if (_health <= 0)
            {
                IsDead = true;
                _health = 0;
                _playerAnim.AnimationDead();
                return;
            }
            _playerAnim.AnimationHit();
        }
    }
    public void EventAnimationDeath()
    {
        
        gameObject.SetActive(false);        
    }
}