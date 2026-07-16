using UnityEngine;

public class PurpleFlyAttack : MonoBehaviour
{
    [SerializeField] int _damage;

    float _timecount;

    PurpleFlyMovement _purpleFlyMovement;
    PurpleFlyAnimation _purpleFlyAnimation;

    void Awake()
    {
        _purpleFlyMovement = GetComponent<PurpleFlyMovement>();
        _purpleFlyAnimation = GetComponent<PurpleFlyAnimation>();
    }

    void Update()
     => UpdateAnimationAttack();

    void UpdateAnimationAttack()
    {
        if (_purpleFlyMovement._circleAreaPlayer != null)
            _purpleFlyAnimation.AnimationAttack(true);
        else
            _purpleFlyAnimation.AnimationAttack(false);
    }

    public void ExecuteAttack(PlayerHealth playerHealth)
    {
        if (playerHealth != null)
        {
            _timecount += Time.deltaTime;

            if (_timecount >= 1)
            {
                playerHealth.TakeDamage(_damage);
                _timecount = 0;
            }
        }
        else
            Debug.Log("REFERENCE PLAYER IS MISSING");
    }    
}