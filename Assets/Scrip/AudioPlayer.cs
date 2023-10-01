using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [Header("shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingVolume = 1f;

    [Header("Damege")]
    [SerializeField] AudioClip DamegeClip;
    [SerializeField] [Range(0f, 1f)] float DamegeVolume = 1f;

    public AudioPlayer instance;

    
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

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamegeClip()
    {
        PlayClip(DamegeClip, DamegeVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
