using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int EnemyAmount { get => _enemyAmount; set => _enemyAmount = value; }

    [SerializeField] int _enemyAmount;

    public bool EndGame { get; set; }

    public GameObject Winner;
    public GameObject Loser;
    public GameObject EndGameScreen;

    public static GameController InstanceGameController;

    void Awake()
        => InstanceGameController = this;

    void Update()
    {
        MoreVelocityEnemy();

        if (EnemyAmount == 0)
        {
            EndGame = true;
            EndGameScreen.SetActive(true);
            Winner.SetActive(true);
        }
    }

    void MoreVelocityEnemy()
    {
        switch (EnemyAmount)
        {
            case 20:
                if (Yellow_Enemy.InstanceYellowEnemy.Speed > 0 && Blue_Enemy.InstanceBlueEnemy._speed > 0 && Red_Enemy.InstanceRedEnemy.Speed > 0)
                {
                    Red_Enemy.InstanceRedEnemy.Speed = 0.4f;
                    Blue_Enemy.InstanceBlueEnemy._speed = 0.3f;
                    Yellow_Enemy.InstanceYellowEnemy.Speed = 0.2f;
                }
                else
                {
                    Red_Enemy.InstanceRedEnemy.Speed = -0.4f;
                    Blue_Enemy.InstanceBlueEnemy._speed = -0.3f;
                    Yellow_Enemy.InstanceYellowEnemy.Speed = -0.2f;
                }                
                break;
            case 12:
                if (Yellow_Enemy.InstanceYellowEnemy.Speed > 0 && Blue_Enemy.InstanceBlueEnemy._speed > 0 && Red_Enemy.InstanceRedEnemy.Speed > 0)
                {
                    Red_Enemy.InstanceRedEnemy.Speed = 0.5f;
                    Blue_Enemy.InstanceBlueEnemy._speed = 0.4f;
                    Yellow_Enemy.InstanceYellowEnemy.Speed = 0.3f;
                }
                else
                {
                    Red_Enemy.InstanceRedEnemy.Speed = -0.5f;
                    Blue_Enemy.InstanceBlueEnemy._speed = -0.4f;
                    Yellow_Enemy.InstanceYellowEnemy.Speed = -0.3f;
                }                
                break;
            case 5:
                if (Yellow_Enemy.InstanceYellowEnemy.Speed > 0 && Blue_Enemy.InstanceBlueEnemy._speed > 0 && Red_Enemy.InstanceRedEnemy.Speed > 0)
                {
                    Red_Enemy.InstanceRedEnemy.Speed = 0.7f;
                    Blue_Enemy.InstanceBlueEnemy._speed = 0.6f;
                    Yellow_Enemy.InstanceYellowEnemy.Speed = 0.5f;
                }
                else
                {
                    Red_Enemy.InstanceRedEnemy.Speed = -0.7f;
                    Blue_Enemy.InstanceBlueEnemy._speed = -0.6f;
                    Yellow_Enemy.InstanceYellowEnemy.Speed = -0.5f;
                }                
                break;
            case 3:
                if (Yellow_Enemy.InstanceYellowEnemy.Speed > 0 && Blue_Enemy.InstanceBlueEnemy._speed > 0 && Red_Enemy.InstanceRedEnemy.Speed > 0)
                {
                    Red_Enemy.InstanceRedEnemy.Speed = 0.9f;
                    Blue_Enemy.InstanceBlueEnemy._speed = 0.8f;
                    Yellow_Enemy.InstanceYellowEnemy.Speed = 0.7f;
                }
                else
                {
                    Red_Enemy.InstanceRedEnemy.Speed = -0.9f;
                    Blue_Enemy.InstanceBlueEnemy._speed = -0.8f;
                    Yellow_Enemy.InstanceYellowEnemy.Speed = -0.7f;
                }                
                break;
        }
    }

    public void ShowEndGame()
    {
        EndGameScreen.SetActive(true);
        Loser.SetActive(true);
        EndGame = true;
    }

    public void BackMenu()
        => SceneManager.LoadScene("Menu");

    public void Restart()
        => SceneManager.LoadScene("Mode_1");
}