using System.Collections.Generic;
using UnityEngine;

public class Spawn_Bullet_Enemy : MonoBehaviour
{
    [SerializeField] GameObject _enemyBullet;
    [SerializeField] List<Transform> _listSpawnBullets = new List<Transform>();

    int _numberSpawn;
    float _timeCount;

    public Vector2 Position;

    public static Spawn_Bullet_Enemy InstanceSpawnBulletEnemy;
    void Awake() 
    { 
        InstanceSpawnBulletEnemy = this; 
        Position = transform.position; 
    }

    void Update()
    {
        if (!GameController.InstanceGameController.EndGame)
        {
            _timeCount += Time.deltaTime;
            if (_timeCount >= 1f)
            {
                transform.position = Position;
                _numberSpawn = Random.Range(0, 17);
                Instantiate(_enemyBullet, _listSpawnBullets[_numberSpawn].position, _listSpawnBullets[_numberSpawn].rotation);
                _timeCount = 0;
            }
        }        
    }
}