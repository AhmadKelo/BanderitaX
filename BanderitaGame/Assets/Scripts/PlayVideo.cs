using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer video;
    public AudioSource sound;
    
    public void PlayVideoAndAudio()
    {
        video.Play();
        sound.Play();
    }

}
