using UnityEngine;

public class MushroomAttack : MonoBehaviour
{
    [SerializeField] float _raycastDistance;
    [SerializeField] float _circleDistanceRadius;
    [SerializeField] int _damage;

    [SerializeField] Transform _raycastDetectPlayer;
    [SerializeField] Transform _circleDistance;
    [SerializeField] LayerMask _layerPlayer;

    public Vector2 RaycastDirection { get; set; } = Vector2.left;
    public IDamageable Idamageable { get; set; }

    public bool IsAttack { get; set; } = false;
    public float TimecountAttack { get; set; }

    MushroomAttack _mushroomAttack;
    MushroomMovement _mushroomMovement;     
    MushroomHealth _mushroomHealth;

    void Awake()
    {
        _mushroomAttack = this;
        _mushroomMovement = GetComponent<MushroomMovement>();
        _mushroomHealth = GetComponent<MushroomHealth>();
    }

    void Update()
    {
        ExecuteAttack();
    }

    void FixedUpdate()
    {
        PlayerBehind();
    }
    void PlayerBehind()
    {
        RaycastHit2D rayhit = Physics2D.Raycast(_raycastDetectPlayer.position, RaycastDirection, _raycastDistance, _layerPlayer);

        if (rayhit.collider != null)
        {
            _mushroomMovement.Flip();
        }
    }
    
    public void ExecuteAttack()
    {
        if (IsAttack && !_mushroomHealth.IsDead)
        {
            TimecountAttack += Time.deltaTime;
            if (TimecountAttack >= 1f)
            {
                Idamageable.TakeDamage(_damage);
                TimecountAttack = 0f;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_raycastDetectPlayer.position, RaycastDirection * _raycastDistance);
    }
}