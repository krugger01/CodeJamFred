using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Sounds
{
    Shoot,
    Heal,
    TakeDamage,
    Death
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // Static instance of the SoundManager class
    public AudioClip[] Clips; // Array of audio clips for different sounds
    [SerializeField] private AudioSource MusicSource, EffectsSource; // Audio sources for music and sound effects

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Set the static instance to this instance if it is null
            DontDestroyOnLoad(this); // Don't destroy the SoundManager when a new scene is loaded
        }
        else
        {
            Destroy(gameObject); // Destroy the duplicate SoundManager instance
        }
    }

    private void Start()
    {
        // Code to execute at the start
    }

    public void SliderIndexer(int index, float value)
    {
        // Adjust the volume based on the slider index
        switch (index)
        {
            case 0:
                ChangeMasterVolume(value);
                break;
            case 1:
                ChangeMusicVolume(value);
                break;
            case 2:
                ChangeEffectsVolume(value);
                break;
        }
    }

    public void PlaySound(Sounds sound)
    {
        // Play the specified sound effect
        switch (sound)
        {
            case Sounds.Shoot:
                EffectsSource.PlayOneShot(Clips[0]);
                break;
            case Sounds.Heal:
                EffectsSource.PlayOneShot(Clips[1]);
                break;
            case Sounds.TakeDamage:
                EffectsSource.PlayOneShot(Clips[2]);
                break;
            case Sounds.Death:
                EffectsSource.PlayOneShot(Clips[3]);
                break;
        }
    }

    public void ChangeMasterVolume(float value)
    {
        // Adjust the master volume
        AudioListener.volume = value;
    }

    public void ChangeMusicVolume(float value)
    {
        // Adjust the music volume
        MusicSource.volume = value;
    }

    public void ChangeEffectsVolume(float value)
    {
        // Adjust the sound effects volume
        EffectsSource.volume = value;
    }
}