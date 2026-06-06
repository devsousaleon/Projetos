using UnityEngine;

public class SlimeHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float _health;

    public bool IsDead { get; set; } = false;

    SlimeAnimation _slimeAnimation;

    void Awake()
    {
        _slimeAnimation = GetComponent<SlimeAnimation>();
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
                _slimeAnimation.AnimationDeath();
                return;
            }
            _slimeAnimation.AnimationDamage();
        }
    }

    public void EventAnimationDeath()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 2f);
    }
}