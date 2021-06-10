using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public int width;
    public int height;

    //Set Resolution
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
}
