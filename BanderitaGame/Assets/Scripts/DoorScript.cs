using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public GameObject EKey;

    int nextLevel;

    bool canEnterNextLevel;

    void Start()
    {
        nextLevel = SceneManager.GetActiveScene().buildIndex +1;
    }

    void Update()
    {
        if(canEnterNextLevel)
        {
            EKey.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Apply Player Progress
                PlayerPrefs.SetInt("PlayerProgressPP", nextLevel);
                // Go to next level
                SceneManager.LoadScene(nextLevel);
            }
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
        EKey.SetActive(false);
    }





}
