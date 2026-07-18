using UnityEngine;

public class WormHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float _health;

    public bool IsDead { get; set; } = false;

    WormAnimation _wormAnimation;

    void Awake()
    {
        _wormAnimation = GetComponent<WormAnimation>();
    }

    public void TakeDamage(int damage)
    {
        if (!IsDead)
        {
            _health -= damage;

            if (_health <= 0)
            {
                _health = 0;
                IsDead = true;
                _wormAnimation.AnimationDeath();
                return;
            }
            _wormAnimation.AnimationDamage();
        }
    }

    public void EventAnimationDeath()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 2f);
    }
}