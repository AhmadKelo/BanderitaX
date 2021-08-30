using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsScript : MonoBehaviour
{

    public int playerProgress = 1; 

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
                for (int i = 1; i <= 3; i++)
                {
                    OpenedLevels[i].SetActive(true);
                    CloseLevels[i].SetActive(false);
                }
                break;
            case 5:
                for (int i = 1; i <= 4; i++)
                {
                    OpenedLevels[i].SetActive(true);
                    CloseLevels[i].SetActive(false);
                }
                break;
            case 6:
                for (int i = 1; i <= 5; i++)
                {
                    OpenedLevels[i].SetActive(true);
                    CloseLevels[i].SetActive(false);
                }
                break;
            case 7:
                for (int i = 1; i <= 6; i++)
                {
                    OpenedLevels[i].SetActive(true);
                    CloseLevels[i].SetActive(false);
                }
                break;
            case 8:
                for (int i = 1; i <= 7; i++)
                {
                    OpenedLevels[i].SetActive(true);
                    CloseLevels[i].SetActive(false);
                }
                break;
            case 9:
                for (int i = 1; i <= 8; i++)
                {
                    OpenedLevels[i].SetActive(true);
                    CloseLevels[i].SetActive(false);
                }
                break;
            case 10:
                for (int i = 1; i <= 9; i++)
                {
                    OpenedLevels[i].SetActive(true);
                    CloseLevels[i].SetActive(false);
                }
                break;
            case 11:
                for (int i = 1; i <= 10; i++)
                {
                    OpenedLevels[i].SetActive(true);
                    CloseLevels[i].SetActive(false);
                }
                break;
            case 12:
                for (int i = 1; i <= 11; i++)
                {
                    OpenedLevels[i].SetActive(true);
                    CloseLevels[i].SetActive(false);
                }
                break;
            case 13:
                for (int i = 1; i <= 12; i++)
                {
                    OpenedLevels[i].SetActive(true);
                    CloseLevels[i].SetActive(false);
                }
                break;
            case 14:
                for (int i = 1; i <= 13; i++)
                {
                    OpenedLevels[i].SetActive(true);
                    CloseLevels[i].SetActive(false);
                }
                break;
            case 15:
                for (int i = 1; i <= 14; i++)
                {
                    OpenedLevels[i].SetActive(true);
                    CloseLevels[i].SetActive(false);
                }
                break;
        }
    }
}
