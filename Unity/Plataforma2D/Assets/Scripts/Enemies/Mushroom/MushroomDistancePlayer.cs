using UnityEngine;

public class MushroomDistancePlayer : MonoBehaviour
{
    [SerializeField] MushroomMovement _mushroomMovement;
    [SerializeField] MushroomAttack _mushroomAttack;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _mushroomAttack.Idamageable = collision.gameObject.GetComponent<IDamageable>();
            _mushroomMovement.PlayerInFront = true;
            _mushroomAttack.IsAttack = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _mushroomMovement.PlayerInFront = false;
            _mushroomAttack.IsAttack = false;
            _mushroomAttack.TimecountAttack = 0;
        }
    }
}