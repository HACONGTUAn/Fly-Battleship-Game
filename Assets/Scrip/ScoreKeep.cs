using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeep : MonoBehaviour
{
    int score;

    public ScoreKeep instance;


    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {

        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }

    public void ResetCore()
    {
        score = 0;
    }
}
