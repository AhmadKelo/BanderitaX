using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{

    public GameObject[] useButtons;
    public GameObject[] usingButtons;

    void Start()
    {
        useButtons[PlayerPrefs.GetInt("Player", 0)].SetActive(false);
        usingButtons[PlayerPrefs.GetInt("Player", 0)].SetActive(true);
    }

    public void ChooseSkin(int skinIndex)
    {
        PlayerPrefs.SetInt("Player", skinIndex);   
    }

}
