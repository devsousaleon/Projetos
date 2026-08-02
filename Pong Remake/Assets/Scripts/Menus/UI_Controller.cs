using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    float _timeCount;
    float _pontuacaoPlayer1;
    float _pontuacaoPlayer2;
    int _indexSceneManager;

    public TMP_Text Pont_P1;
    public TMP_Text Pont_P2;
    public GameObject ScreenEndGame;
    public GameObject Win_P1;
    public GameObject Win_P2;
    public GameObject Particle_Rain;
    public Light2D SpotLight_1;
    public Light2D SpotLight_2;
    public Light2D SpotLight_3;
    public Light2D SpotLight_4;
    public Light2D PedestrialSignal_1;
    public Light2D PedestrialSignal_2;
    public Light2D GlobalLight;

    public float Ponto_Player1 { get => _pontuacaoPlayer1; set => _pontuacaoPlayer1 = value; }
    public float Ponto_Player2 { get => _pontuacaoPlayer2; set => _pontuacaoPlayer2 = value; }
    public bool EndGame {  get; private set; }

    public static UI_Controller InstanceUIController;

    void Awake()
        => InstanceUIController = this;

    void Start()
    {
        _indexSceneManager = SceneManager.GetActiveScene().buildIndex;

        if (_indexSceneManager == 1)
            ActiveEffectField();

        else
            ActiveEffectStreet();
    }

    void Update()
    {
        Pont_P1.text = _pontuacaoPlayer1.ToString();
        Pont_P2.text = _pontuacaoPlayer2.ToString();
        if (_pontuacaoPlayer1 == 2)
        {
            EndGame = true;
            ScreenEndGame.SetActive(true);
            Win_P1.SetActive(true);
            SpotLight_1.intensity = 0.5f;
            SpotLight_2.intensity = 0.5f;
            SpotLight_3.intensity = 0.5f;
            SpotLight_4.intensity = 0.5f;
            GlobalLight.intensity = 0.1f;
        }
        if (_pontuacaoPlayer2 == 2)
        {
            EndGame = true;
            ScreenEndGame.SetActive(true);
            Win_P2.SetActive(true);
            SpotLight_1.intensity = 0.5f;
            SpotLight_2.intensity = 0.5f;
            SpotLight_3.intensity = 0.5f;
            SpotLight_4.intensity = 0.5f;
            GlobalLight.intensity = 0.1f;
        }
        if (Game_Mode_Controller.Noite)
            PedestrialSignal_Blink();
    }

    void ActiveEffectField()
    {
        if (Game_Mode_Controller.Chuva)
            Particle_Rain.SetActive(true);
    }

    void ActiveEffectStreet()
    {
        if (Game_Mode_Controller.Dia)
        {
            GlobalLight.intensity = 1f;
            SpotLight_1.intensity = 0;
            SpotLight_2.intensity = 0;
            SpotLight_3.intensity = 0;
            SpotLight_4.intensity = 0;
        }
        else if(Game_Mode_Controller.Noite)
        {
            GlobalLight.intensity = 0.1f;
            SpotLight_1.intensity = 1;
            SpotLight_2.intensity = 1;
            SpotLight_3.intensity = 1;
            SpotLight_4.intensity = 1;
        }
    }

    void PedestrialSignal_Blink()
    {
        _timeCount += Time.deltaTime;
        if (_timeCount >= 1f)
        {
            PedestrialSignal_1.color = Color.red;
            PedestrialSignal_2.color = Color.red;
            PedestrialSignal_1.intensity = 1f;
            PedestrialSignal_2.intensity = 1f;
            
            if (_timeCount >= 2f)
            {
                PedestrialSignal_1.color = Color.green;
                PedestrialSignal_2.color = Color.green;
            }
            if (_timeCount >= 3f)
            {
                PedestrialSignal_1.intensity = 0f;
                PedestrialSignal_2.intensity = 0f;
                _timeCount = 0f;
            }
        }        
    }

    public void RestartGame()
        => SceneManager.LoadScene(_indexSceneManager);

    public void MenuGame()
        => SceneManager.LoadScene("Menu");
}