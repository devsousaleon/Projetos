using UnityEngine;

public class BomberGoblinMovement : MonoBehaviour
{
    [SerializeField] Transform _raySeePlayer;
    [SerializeField] Transform _behindRaySeePlayer;
    [SerializeField] LayerMask _layerPlayer;

    [SerializeField] float _distanceSeePlayer;

    Vector2 _directionFront = Vector2.right;
    Vector2 _behindDirectionFront = Vector2.left;
    BomberGoblinAttack _bomberGoblinAttack;

    void Awake()
    {
        _bomberGoblinAttack = GetComponent<BomberGoblinAttack>();
    }

    void FixedUpdate()
    {
        SeeingPlayer();
    }

    void SeeingPlayer()
    {
        RaycastHit2D rayhit = Physics2D.Raycast(_raySeePlayer.position, _directionFront, _distanceSeePlayer, _layerPlayer);
        RaycastHit2D behindrayhit = Physics2D.Raycast(_behindRaySeePlayer.position, _behindDirectionFront, _distanceSeePlayer, _layerPlayer);

        if (rayhit.collider != null)
            _bomberGoblinAttack.ExecuteAttack();

        if (behindrayhit.collider != null)
            Flip();
    }

    public void Flip()
    {
        _directionFront = -_directionFront;
        _behindDirectionFront = -_behindDirectionFront;
        _bomberGoblinAttack._facingDirection *= -1;

        Vector3 scale = transform.localScale;
        scale.x *= -1;

        transform.localScale = scale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_raySeePlayer.position, _directionFront * _distanceSeePlayer);
        Gizmos.DrawRay(_behindRaySeePlayer.position, _behindDirectionFront * _distanceSeePlayer);
    }
}