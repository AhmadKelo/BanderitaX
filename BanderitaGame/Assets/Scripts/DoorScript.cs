using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public GameObject EKey;

    public int nextLevel;

    bool canEnterNextLevel;
    void Start()
    {
        
    }

    void Update()
    {
        if(canEnterNextLevel)
        {
            EKey.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerPrefs.SetInt("PlayerProgressPP", nextLevel);
                SceneManager.LoadScene(nextLevel);
            }
        }
        else if(!canEnterNextLevel)
        {
            EKey.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        canEnterNextLevel = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {   
        canEnterNextLevel = false;
    }





}
