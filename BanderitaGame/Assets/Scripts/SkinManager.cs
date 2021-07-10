using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{

    public GameObject[] useButtons;
    public GameObject[] usingButtons;

    public GameObject[] locked;

    [Range(0,25)]public int openedPlayers;

    void Start()
    {

        useButtons[PlayerPrefs.GetInt("Player", 0)].SetActive(false);
        usingButtons[PlayerPrefs.GetInt("Player", 0)].SetActive(true);

        openedPlayers = PlayerPrefs.GetInt("PlayerProgressPP", 0);

        
        if(openedPlayers >= 5)
        {
            locked[1].SetActive(false);
            locked[2].SetActive(false);
        }
        else if(openedPlayers >= 10)
            locked[2].SetActive(false);


        
        
    }

    public void ChooseSkin(int skinIndex)
    {
        PlayerPrefs.SetInt("Player", skinIndex);   
    }

}
