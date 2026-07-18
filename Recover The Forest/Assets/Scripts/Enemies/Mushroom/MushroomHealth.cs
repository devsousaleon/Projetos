using UnityEngine;

public class MushroomHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float _health;

    public bool IsDead { get; set; } = false;

    MushroomAnimation _mushroomAnimation;

    void Awake()
    {
        _mushroomAnimation = GetComponent<MushroomAnimation>();
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
                _mushroomAnimation.AnimationDeath();
                return;
            }
            _mushroomAnimation.AnimationDamage();
        }
    }

    public void EventAnimationDeath()
    {        
        gameObject.SetActive(false);
        Destroy(gameObject, 2f);
    }
}