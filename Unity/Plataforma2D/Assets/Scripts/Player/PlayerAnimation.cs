using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void AnimationMovement(bool jumping, float movement)
    {
        _anim.SetInteger("valueTransition", jumping ? 2 : movement != 0 && !jumping ? 1 : 0);
    }

    public void AnimationAttacking()
    {
        _anim.SetTrigger("attack");
    }

    public void AnimationDead()
    {
        _anim.SetTrigger("dead");
    }

    public void AnimationHit()
    {
        _anim.SetTrigger("damage");
    }
}