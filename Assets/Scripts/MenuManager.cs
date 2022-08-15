using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject PauseButton;
    public GameObject ResumeButton;
    public void Restart()
    {
        GateComponent.DeadActive = false;
        SpawnedArrow.zero = false;
        SceneManager.LoadScene(0);
        LevelManager.miniGame = false;
    }
    public void Resume()
    {
        PauseButton.SetActive(true);
        ResumeButton.SetActive(false);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        ResumeButton.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }
}
