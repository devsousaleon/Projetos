using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    bool isAttacking;

    [SerializeField] float _attackAreaRadius;
    [SerializeField] int _damageAttack;

    [SerializeField] Transform _attackAreaPos;
    [SerializeField] LayerMask _enemyLayer;

    PlayerAnimation _playerAnim;
    PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        ExecuteAttack();
    }

    void ExecuteAttack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking && !_playerHealth.IsDead)
        {
            Attacking();
        }
    }

    void Attacking()
    {
        _playerAnim.AnimationAttacking();

        Collider2D attackHit = Physics2D.OverlapCircle(_attackAreaPos.position, _attackAreaRadius, _enemyLayer);

        if (attackHit != null)
        {
            IDamageable Idamage = attackHit.GetComponent<IDamageable>();
            Idamage?.TakeDamage(_damageAttack);
        }
    }

    public void EndAttack()
    {
        isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_attackAreaPos.position, _attackAreaRadius);
    }
}