using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public AudioSource music;
    public AudioClip endClip;


    public void endGame()
    {
        music.clip = endClip;
        music.Play();
    }

    public void playerDied()
    {
        music.Pause();
    }
    public void playerRespawned()
    {
        music.UnPause();
    }
}
