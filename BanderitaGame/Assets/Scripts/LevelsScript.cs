using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsScript : MonoBehaviour
{

    public int playerProgress = 1; //  I Will Turn it to Player Prefs

    public GameObject[] OpenedLevels;  // levels That Are Opened
    public GameObject[] CloseLevels;   // levels That Are Close

    void Start()
    {
        playerProgress = PlayerPrefs.GetInt("PlayerProgressPP", 1) ;

        switch (playerProgress) // Level Manager
        {
            case 2:
                OpenedLevels[1].SetActive(true);
                CloseLevels[1].SetActive(false);
                break;
            case 3:
                OpenedLevels[1].SetActive(true);
                CloseLevels[1].SetActive(false);
                OpenedLevels[2].SetActive(true);
                CloseLevels[2].SetActive(false);
                break;
            case 4:
                OpenedLevels[1].SetActive(true);
                CloseLevels[1].SetActive(false);
                OpenedLevels[2].SetActive(true);
                CloseLevels[2].SetActive(false);
                OpenedLevels[3].SetActive(true);
                CloseLevels[3].SetActive(false);
                break;
            case 5:
                OpenedLevels[1].SetActive(true);
                CloseLevels[1].SetActive(false);
                OpenedLevels[2].SetActive(true);
                CloseLevels[2].SetActive(false);
                OpenedLevels[3].SetActive(true);
                CloseLevels[3].SetActive(false);
                OpenedLevels[4].SetActive(true);
                CloseLevels[4].SetActive(false);
                break;
            case 6:
                OpenedLevels[1].SetActive(true);
                CloseLevels[1].SetActive(false);
                OpenedLevels[2].SetActive(true);
                CloseLevels[2].SetActive(false);
                OpenedLevels[3].SetActive(true);
                CloseLevels[3].SetActive(false);
                OpenedLevels[4].SetActive(true);
                CloseLevels[4].SetActive(false);
                OpenedLevels[5].SetActive(true);
                CloseLevels[5].SetActive(false);
                break;
            case 7:
                OpenedLevels[1].SetActive(true);
                CloseLevels[1].SetActive(false);
                OpenedLevels[2].SetActive(true);
                CloseLevels[2].SetActive(false);
                OpenedLevels[3].SetActive(true);
                CloseLevels[3].SetActive(false);
                OpenedLevels[4].SetActive(true);
                CloseLevels[4].SetActive(false);
                OpenedLevels[5].SetActive(true);
                CloseLevels[5].SetActive(false);
                OpenedLevels[6].SetActive(true);
                CloseLevels[6].SetActive(false);
                break;
            case 8:
                OpenedLevels[1].SetActive(true);
                CloseLevels[1].SetActive(false);
                OpenedLevels[2].SetActive(true);
                CloseLevels[2].SetActive(false);
                OpenedLevels[3].SetActive(true);
                CloseLevels[3].SetActive(false);
                OpenedLevels[4].SetActive(true);
                CloseLevels[4].SetActive(false);
                OpenedLevels[5].SetActive(true);
                CloseLevels[5].SetActive(false);
                OpenedLevels[6].SetActive(true);
                CloseLevels[6].SetActive(false);
                OpenedLevels[7].SetActive(true);
                CloseLevels[7].SetActive(false);
                break;
            case 9:
                OpenedLevels[1].SetActive(true);
                CloseLevels[1].SetActive(false);
                OpenedLevels[2].SetActive(true);
                CloseLevels[2].SetActive(false);
                OpenedLevels[3].SetActive(true);
                CloseLevels[3].SetActive(false);
                OpenedLevels[4].SetActive(true);
                CloseLevels[4].SetActive(false);
                OpenedLevels[5].SetActive(true);
                CloseLevels[5].SetActive(false);
                OpenedLevels[6].SetActive(true);
                CloseLevels[6].SetActive(false);
                OpenedLevels[7].SetActive(true);
                CloseLevels[7].SetActive(false);
                OpenedLevels[8].SetActive(true);
                CloseLevels[8].SetActive(false);
                break;
            case 10:
                OpenedLevels[1].SetActive(true);
                CloseLevels[1].SetActive(false);
                OpenedLevels[2].SetActive(true);
                CloseLevels[2].SetActive(false);
                OpenedLevels[3].SetActive(true);
                CloseLevels[3].SetActive(false);
                OpenedLevels[4].SetActive(true);
                CloseLevels[4].SetActive(false);
                OpenedLevels[5].SetActive(true);
                CloseLevels[5].SetActive(false);
                OpenedLevels[6].SetActive(true);
                CloseLevels[6].SetActive(false);
                OpenedLevels[7].SetActive(true);
                CloseLevels[7].SetActive(false);
                OpenedLevels[8].SetActive(true);
                CloseLevels[8].SetActive(false);
                OpenedLevels[9].SetActive(true);
                CloseLevels[9].SetActive(false);
                break;
            case 11:
                OpenedLevels[1].SetActive(true);
                CloseLevels[1].SetActive(false);
                OpenedLevels[2].SetActive(true);
                CloseLevels[2].SetActive(false);
                OpenedLevels[3].SetActive(true);
                CloseLevels[3].SetActive(false);
                OpenedLevels[4].SetActive(true);
                CloseLevels[4].SetActive(false);
                OpenedLevels[5].SetActive(true);
                CloseLevels[5].SetActive(false);
                OpenedLevels[6].SetActive(true);
                CloseLevels[6].SetActive(false);
                OpenedLevels[7].SetActive(true);
                CloseLevels[7].SetActive(false);
                OpenedLevels[8].SetActive(true);
                CloseLevels[8].SetActive(false);
                OpenedLevels[9].SetActive(true);
                CloseLevels[9].SetActive(false);
                OpenedLevels[10].SetActive(true);
                CloseLevels[10].SetActive(false);
                break;
            case 12:
                OpenedLevels[1].SetActive(true);
                CloseLevels[1].SetActive(false);
                OpenedLevels[2].SetActive(true);
                CloseLevels[2].SetActive(false);
                OpenedLevels[3].SetActive(true);
                CloseLevels[3].SetActive(false);
                OpenedLevels[4].SetActive(true);
                CloseLevels[4].SetActive(false);
                OpenedLevels[5].SetActive(true);
                CloseLevels[5].SetActive(false);
                OpenedLevels[6].SetActive(true);
                CloseLevels[6].SetActive(false);
                OpenedLevels[7].SetActive(true);
                CloseLevels[7].SetActive(false);
                OpenedLevels[8].SetActive(true);
                CloseLevels[8].SetActive(false);
                OpenedLevels[9].SetActive(true);
                CloseLevels[9].SetActive(false);
                OpenedLevels[10].SetActive(true);
                CloseLevels[10].SetActive(false);
                OpenedLevels[11].SetActive(true);
                CloseLevels[11].SetActive(false);
                break;
            case 13:
                OpenedLevels[1].SetActive(true);
                CloseLevels[1].SetActive(false);
                OpenedLevels[2].SetActive(true);
                CloseLevels[2].SetActive(false);
                OpenedLevels[3].SetActive(true);
                CloseLevels[3].SetActive(false);
                OpenedLevels[4].SetActive(true);
                CloseLevels[4].SetActive(false);
                OpenedLevels[5].SetActive(true);
                CloseLevels[5].SetActive(false);
                OpenedLevels[6].SetActive(true);
                CloseLevels[6].SetActive(false);
                OpenedLevels[7].SetActive(true);
                CloseLevels[7].SetActive(false);
                OpenedLevels[8].SetActive(true);
                CloseLevels[8].SetActive(false);
                OpenedLevels[9].SetActive(true);
                CloseLevels[9].SetActive(false);
                OpenedLevels[10].SetActive(true);
                CloseLevels[10].SetActive(false);
                OpenedLevels[11].SetActive(true);
                CloseLevels[11].SetActive(false);
                OpenedLevels[12].SetActive(true);
                CloseLevels[12].SetActive(false);
                break;
            case 14:
                OpenedLevels[1].SetActive(true);
                CloseLevels[1].SetActive(false);
                OpenedLevels[2].SetActive(true);
                CloseLevels[2].SetActive(false);
                OpenedLevels[3].SetActive(true);
                CloseLevels[3].SetActive(false);
                OpenedLevels[4].SetActive(true);
                CloseLevels[4].SetActive(false);
                OpenedLevels[5].SetActive(true);
                CloseLevels[5].SetActive(false);
                OpenedLevels[6].SetActive(true);
                CloseLevels[6].SetActive(false);
                OpenedLevels[7].SetActive(true);
                CloseLevels[7].SetActive(false);
                OpenedLevels[8].SetActive(true);
                CloseLevels[8].SetActive(false);
                OpenedLevels[9].SetActive(true);
                CloseLevels[9].SetActive(false);
                OpenedLevels[10].SetActive(true);
                CloseLevels[10].SetActive(false);
                OpenedLevels[11].SetActive(true);
                CloseLevels[11].SetActive(false);
                OpenedLevels[12].SetActive(true);
                CloseLevels[12].SetActive(false);
                OpenedLevels[13].SetActive(true);
                CloseLevels[13].SetActive(false);
                break;
            case 15:
                OpenedLevels[1].SetActive(true);
                CloseLevels[1].SetActive(false);
                OpenedLevels[2].SetActive(true);
                CloseLevels[2].SetActive(false);
                OpenedLevels[3].SetActive(true);
                CloseLevels[3].SetActive(false);
                OpenedLevels[4].SetActive(true);
                CloseLevels[4].SetActive(false);
                OpenedLevels[5].SetActive(true);
                CloseLevels[5].SetActive(false);
                OpenedLevels[6].SetActive(true);
                CloseLevels[6].SetActive(false);
                OpenedLevels[7].SetActive(true);
                CloseLevels[7].SetActive(false);
                OpenedLevels[8].SetActive(true);
                CloseLevels[8].SetActive(false);
                OpenedLevels[9].SetActive(true);
                CloseLevels[9].SetActive(false);
                OpenedLevels[10].SetActive(true);
                CloseLevels[10].SetActive(false);
                OpenedLevels[11].SetActive(true);
                CloseLevels[11].SetActive(false);
                OpenedLevels[12].SetActive(true);
                CloseLevels[12].SetActive(false);
                OpenedLevels[13].SetActive(true);
                CloseLevels[13].SetActive(false);
                OpenedLevels[14].SetActive(true);
                CloseLevels[14].SetActive(false);
                break;
        }
    }

    void Update()
    {
        

        
    }
}
