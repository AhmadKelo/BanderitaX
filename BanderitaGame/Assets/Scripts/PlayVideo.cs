using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer video;
    public AudioSource videoAudio;

    public void PlayVideoAndAudio()
    {
        video.Play();
        videoAudio.Play();
    }
}
