using UnityEngine;

public class BomberGoblinAttack : MonoBehaviour
{
    [SerializeField] Transform _posAttack;
    [SerializeField] GameObject _bomb;
        
    float timecount;

    public int _facingDirection { get; set; } = 1;

    BomberGoblinAnimation _bomberGoblinAnimation;

    void Awake()
    {
        _bomberGoblinAnimation = GetComponent<BomberGoblinAnimation>();
    } 
    public void ExecuteAttack()
    {
        timecount += Time.fixedDeltaTime;

        if(timecount >= 1f)
        {
            _bomberGoblinAnimation.AnimationAttack();
            timecount = 0f;
        }
    }

    public void ThrowBomb()
    {
        BombAction_BomberGoblin bombScript = Instantiate(_bomb, _posAttack.position, _posAttack.rotation).GetComponent<BombAction_BomberGoblin>();
        bombScript.SetDirection(_facingDirection);
    }            
}