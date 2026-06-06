using UnityEngine;

public class GoblinDistancePlayer : MonoBehaviour
{
    [SerializeField] GoblinMovement _goblinMovement;
    [SerializeField] GoblinAttack _goblinAttack;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _goblinAttack.Idamageable = collision.gameObject.GetComponent<IDamageable>();
            _goblinMovement.PlayerInFront = true;
            _goblinAttack.IsAttack = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _goblinMovement.PlayerInFront = false;
            _goblinAttack.IsAttack = false;
            _goblinAttack.TimecountAttack = 0;
        }
    }
}