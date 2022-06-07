using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance; // static koyarak her script taraf�ndan ula��labilir yapt�k.

    public AudioSource[] soundEffects;

    private void Awake()
    {
        instance = this; // Bu script bir degiskendir.
    }

    public void SoundEffect(int chooseSound)
    {
        soundEffects[chooseSound].Stop();
        soundEffects[chooseSound].Play();
    }

    public void RandomSoundEffect(int chooseSound)
    {
        soundEffects[chooseSound].Stop();
        soundEffects[chooseSound].pitch = Random.Range(0.75f, 1f); // Rastgele ses ��kar�r.
        soundEffects[chooseSound].Play();
    }

}
