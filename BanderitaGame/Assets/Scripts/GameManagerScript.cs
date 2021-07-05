using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManagerScript : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;

    public GameObject[] players;

    void Start()
    {
        players[PlayerPrefs.GetInt("Player", 0)].SetActive(true);
        vcam.Follow = players[PlayerPrefs.GetInt("Player", 0)].transform;
    }


    void Update()
    {
        
    }
}
