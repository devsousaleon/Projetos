using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] GameObject _options;

    public void StartGame()
        => SceneManager.LoadScene("Mode_1");

    public void OpenOptions()
        => _options.SetActive(true);

    public void CloseOptions()
        => _options.SetActive(false);

    public void ExitGame()
    {
        if(Debug.isDebugBuild)
            UnityEditor.EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
}