using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIover : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeep scoreKeeper;

     void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeep>();
    }
    void Start()
    {
        scoreText.text = "You Scored:\n" + scoreKeeper.GetScore();
    }
}
