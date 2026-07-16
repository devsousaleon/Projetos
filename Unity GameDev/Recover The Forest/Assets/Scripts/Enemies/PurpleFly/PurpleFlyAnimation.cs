using UnityEngine;

public class PurpleFlyAnimation : MonoBehaviour
{
    Animator _anim;

    void Awake()
        => _anim = GetComponent<Animator>();

    public void AnimationDeath()
        => _anim.SetTrigger("death");

    public void AnimationDamage()
        => _anim.SetTrigger("hit");

    public void AnimationAttack(bool boolExecuteAttack)
        => _anim.SetBool("attack", boolExecuteAttack);
}