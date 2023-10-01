using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIdisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeep scoreKeeper;
    // Start is called before the first frame update

     void Awake()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeep>();
    }
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("0000000000");

    }
}
