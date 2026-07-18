using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
    Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void AnimationDamage()
    {
        _anim.SetTrigger("hit");
    }
    public void AnimationDeath()
    {
        _anim.SetTrigger("death");
    }
    public void AnimationMove()
    {
        _anim.SetInteger("transition", 1);
    }
    public void AnimationIdle()
    {
        _anim.SetInteger("transition", 0);
    }
}