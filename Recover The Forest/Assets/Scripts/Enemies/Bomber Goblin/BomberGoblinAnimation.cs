using UnityEngine;

public class BomberGoblinAnimation : MonoBehaviour
{
    Animator _anim;
    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void AnimationDeath()
    {
        _anim.SetTrigger("death");
    }

    public void AnimationDamage()
    {
        _anim.SetTrigger("hit");
    }
    public void AnimationAttack()
    {
        _anim.SetTrigger("attack");
    }
}