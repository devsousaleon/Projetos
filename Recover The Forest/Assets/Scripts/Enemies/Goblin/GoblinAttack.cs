using UnityEngine;

public class GoblinAttack : MonoBehaviour
{
    [SerializeField] int _damage;

    public IDamageable Idamageable { get; set; }

    public bool IsAttack { get; set; } = false;
    public float TimecountAttack { get; set; }

    GoblinHealth _goblinHealth;
    GoblinAnimation _goblinAnimation;

    void Awake()
    {
        _goblinHealth = GetComponent<GoblinHealth>();
        _goblinAnimation = GetComponent<GoblinAnimation>();
    }

    void Update()
    {
        ExecuteAttack();
    }

    public void ExecuteAttack()
    {
        if (IsAttack && !_goblinHealth.IsDead)
        {
            TimecountAttack += Time.deltaTime;
            if (TimecountAttack >= 1f)
            {
                _goblinAnimation.AnimationAttack();
                Idamageable.TakeDamage(_damage);
                TimecountAttack = 0f;
            }
        }
    }
}