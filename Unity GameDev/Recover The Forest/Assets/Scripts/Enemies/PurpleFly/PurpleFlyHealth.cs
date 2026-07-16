using UnityEngine;

public class PurpleFlyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float _health;

    public bool IsDead { get; set; } = false;

    PurpleFlyAnimation _purpleFlyAnimation;

    void Awake()
        => _purpleFlyAnimation = GetComponent<PurpleFlyAnimation>();

    public void TakeDamage(int damage)
    {
        if (!IsDead)
        {
            _health -= damage;

            if (_health <= 0)
            {
                _health = 0;
                IsDead = true;
                _purpleFlyAnimation.AnimationDeath();
                return;
            }
            _purpleFlyAnimation.AnimationDamage();
        }
    }

    public void EventAnimationDeath()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 2f);
    }
}