using UnityEngine;

public class WormAnimation : MonoBehaviour
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
}