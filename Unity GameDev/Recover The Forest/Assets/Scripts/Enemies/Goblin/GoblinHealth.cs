using UnityEngine;

public class GoblinHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float _health;

    public bool IsDead { get; set; }

    GoblinAnimation _goblinAnimation;

    void Awake()
    {
        _goblinAnimation = GetComponent<GoblinAnimation>();
    }

    public void TakeDamage(int damage)
    {
        if (IsDead)
            return;

        _health -= damage;

        if( _health <= 0 )
        {
            IsDead = true;
            _goblinAnimation.AnimationDeath();
            return;
        }
        _goblinAnimation.AnimationHit();
    }
}