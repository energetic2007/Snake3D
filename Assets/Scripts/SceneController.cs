using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject infoPanel;
    public static int PreviousSceneIndex;
    public void Select(int numberInBuild)
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        if (levelReached < numberInBuild) PlayerPrefs.SetInt("levelReached", numberInBuild);
        SceneManager.LoadScene(numberInBuild);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Pause()
    {
        Time.timeScale = 0;
        infoPanel.SetActive(true);
        if(Input.touchCount > 0)
        {
            Restime();
        }
    }
    public void Restime()
    {
        Time.timeScale = 1;
        infoPanel.SetActive(false);
    }
    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(PreviousSceneIndex);
    }
}
