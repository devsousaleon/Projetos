using UnityEngine;

public class BomberGoblinHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float _health;

    public bool IsDead { get; set; } = false;

    BomberGoblinAnimation _bomberGoblinAnimation;

    void Awake()
    {
        _bomberGoblinAnimation = GetComponent<BomberGoblinAnimation>();
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
                _bomberGoblinAnimation.AnimationDeath();
                return;
            }
            _bomberGoblinAnimation.AnimationDamage();
        }
    }

    public void EventAnimationDeath()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 2f);
    }
}