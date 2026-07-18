using UnityEngine;

public class GoblinAnimation : MonoBehaviour
{
    Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }       
    public void AnimationIdle()
    {
        _anim.SetInteger("transition", 0);
    }
    public void AnimationRun()
    {
        _anim.SetInteger("transition", 1);
    }
    public void AnimationAttack()
    {
        _anim.SetTrigger("attack");
    }
    public void AnimationDeath()
    {
        _anim.SetTrigger("death");
    }
    public void AnimationHit()
    {
        _anim.SetTrigger("hit");
    }
}