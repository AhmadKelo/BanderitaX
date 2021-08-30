using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManagerScript : MonoBehaviour
{
    // THIS SCRPIT SPAWNS THE CHOSEN PLAYER

    public CinemachineVirtualCamera vcam;

    Transform Player;

    public Transform[] players;

    void Start()
    {
        //Attach Players Parent
        Player = GameObject.Find("Player").transform;

        //Make Size of the array player count
        players = new Transform[Player.gameObject.transform.childCount];

        //Attach Players to the array
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = Player.gameObject.transform.GetChild(i);
        }


        // Spawn Chosen Player
        players[PlayerPrefs.GetInt("Player", 0)].gameObject.SetActive(true);
        if(vcam != null)
        vcam.Follow = players[PlayerPrefs.GetInt("Player", 0)].transform;

    }

}
