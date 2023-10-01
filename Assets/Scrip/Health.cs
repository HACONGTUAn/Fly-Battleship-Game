using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    ScoreKeep scoreKeeper;
    LevelManager levelManager;
    AudioPlayer audioPlayer;
     void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreKeeper = FindObjectOfType<ScoreKeep>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamegeDealer damegeDaeler = collision.GetComponent<DamegeDealer>();

        if(damegeDaeler != null)
        {
            TakeDamage(damegeDaeler.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayDamegeClip();
            ShakeCamera();
            damegeDaeler.Hit();
        }
    }

   void ShakeCamera()
    {
       if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }
    public int GetHealth()
    {
        return health;
    }
    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance= Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
