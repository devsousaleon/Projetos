using UnityEngine;

public class Wall_Detect_Collider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.layer)
        {
            case 7:
                Red_Enemy.InstanceRedEnemy.Position.y -= 0.4f;
                Blue_Enemy.InstanceBlueEnemy.Position.y -= 0.4f;
                Yellow_Enemy.InstanceYellowEnemy._positionInScene.y -= 0.4f;

                Red_Enemy.InstanceRedEnemy.Speed *= -1;
                Blue_Enemy.InstanceBlueEnemy._speed *= -1;
                Yellow_Enemy.InstanceYellowEnemy.Speed *= -1;

                Spawn_Bullet_Enemy.InstanceSpawnBulletEnemy.Position.y -= 0.4f;
                break;

            case 8:
            case 9:
                Red_Enemy.InstanceRedEnemy.Position.y -= 0.4f;
                Blue_Enemy.InstanceBlueEnemy.Position.y -= 0.4f;
                Yellow_Enemy.InstanceYellowEnemy._positionInScene.y -= 0.4f;

                Red_Enemy.InstanceRedEnemy.Speed *= -1;
                Blue_Enemy.InstanceBlueEnemy._speed *= -1;
                Yellow_Enemy.InstanceYellowEnemy.Speed *= -1;
                break;
        }
    }
}