using UnityEngine;

public class MushroomAnimation : MonoBehaviour
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

    public void AnimationCrushed()
    {
        _anim.SetTrigger("crushed");
    }
}