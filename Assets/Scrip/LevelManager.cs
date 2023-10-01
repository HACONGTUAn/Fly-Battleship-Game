using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{[SerializeField] float scenLoadDeplay = 2f;
    ScoreKeep scoreKeeper;

     void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeep>();
    }
    public void LoadGame()
    {
//        scoreKeeper.ResetCore();
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("MainQuit", scenLoadDeplay));
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game..");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string scaneName,float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scaneName);
    }
}
