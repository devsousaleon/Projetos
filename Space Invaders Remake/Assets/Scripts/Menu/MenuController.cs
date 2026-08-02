using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject _optionsMenu;
    [SerializeField] GameObject _startGameMenu;

    #region StartMenu
    public void StartGame()
        => SceneManager.LoadScene("Mode_1");

    public void OpenStartGame()
        => _startGameMenu.SetActive(true);

    public void CloseStartGame()
        => _startGameMenu.SetActive(false);
    #endregion

    #region OPTIONS
    public void OpenOptions()
        => _optionsMenu.SetActive(true);

    public void CloseOptions()
        => _optionsMenu.SetActive(false);
    #endregion

    public void CloseGame()
    {
        if(Debug.isDebugBuild)
            UnityEditor.EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
}