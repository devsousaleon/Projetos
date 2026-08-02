using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int HighScore { get; set; }
    public bool EndGame { get; private set; }

    public TMP_Text HighScorePoint;
    public TMP_Text HighScorePointInGame;
    public GameObject ScreenEndGame;    

    public static GameController InstanceGameController;

    void Awake()
        => InstanceGameController = this;

    void Update()
        => ResetGame();

    void ResetGame()
    {
        if (Ball.InstanceBall.QuantityBlocks <= 0)
        {
            ScreenEndGame.SetActive(true);
            EndGame = true;
        }
    }

    public void UpdateHighScore(int pointHighScore)
    {
        HighScore += pointHighScore;
        HighScorePoint.text = GameController.InstanceGameController.HighScore.ToString();
        HighScorePointInGame.text = GameController.InstanceGameController.HighScore.ToString();
    }

    public void RestartGame()
        => SceneManager.LoadScene("Mode_1");

    public void Menu()
        => SceneManager.LoadScene("Menu");
}