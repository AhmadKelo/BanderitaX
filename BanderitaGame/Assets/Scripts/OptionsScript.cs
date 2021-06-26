using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{

    #region Resolution Variables
        
    public int width;
    public int height;

    #endregion

    #region Audio Vaiables
        
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    #endregion
    

    void Start()
    {
        audioMixer.ClearFloat("volume");
    }
        
        
    #region Resolution Functions
        
    public void SetWidth(int newWidth)
    {
        width = newWidth;
    }

    public void SetHeight(int newHeight)
    {
        height = newHeight;
    }

    public void SetRes()
    {
        Screen.SetResolution(width, height, true);
    }

    #endregion

    #region Volume Functions

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }   

    #endregion
    
}
