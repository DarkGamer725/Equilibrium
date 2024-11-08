using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] string mainMenuScene;

    public delegate void OnPauseDelegate(bool isPaused);
    event OnPauseDelegate OnPauseEvent;
    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        this.gameObject.SetActive(false);
        if (OnPauseEvent != null)
        {
            OnPauseEvent(true);
        }
    }
    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        this.gameObject.SetActive(true);
        if (OnPauseEvent != null)
        {
            OnPauseEvent(false);
        }
    }

    public void RegisterOnPause(OnPauseDelegate function)
    {
        OnPauseEvent += function;
    }

    public void UnregisterOnPause(OnPauseDelegate function)
    {
        OnPauseEvent -= function;
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
