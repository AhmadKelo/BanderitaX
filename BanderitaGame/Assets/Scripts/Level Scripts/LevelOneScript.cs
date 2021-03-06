using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LevelOneScript : MonoBehaviour
{
    public GameObject playerG;

    bool disActivateCanvas = false;

    GameObject canvas1;
    GameObject canvas2;

    Animator anim;
    Animator anim2;

    GameObject subscribeButton;

    VideoPlayer videoPlayer1;
    VideoPlayer videoPlayer2;

    public AudioSource audioSource1;
    public AudioSource audioSource2;

    public GameManagerScript gameManagerScript;
    void Start()
    {

        //Attach Video Players
        videoPlayer1 = GameObject.Find("Canvas/Video Player").GetComponent<VideoPlayer>();
        videoPlayer2 = GameObject.Find("Canvas 2/Video Player").GetComponent<VideoPlayer>();

        //Attach canvases
        canvas1 = GameObject.Find("Canvas");
        canvas2 = GameObject.Find("Canvas 2");

        //Attach Anims
        anim = canvas1.GetComponent<Animator>();
        anim2 = canvas2.GetComponent<Animator>();

        //Attach Subscribe Button
        subscribeButton = GameObject.Find("Canvas/SubscribeButton");

        //Disable Subscribe Button
        subscribeButton.SetActive(false);

        //Prepare Videos For Better Performance   
        videoPlayer1.Prepare();
        videoPlayer2.Prepare();

        //Attach Player To the Using Player
        playerG = GameObject.Find("Player").transform.GetChild(PlayerPrefs.GetInt("Player", 0)).gameObject;

    }


    void Update()
    {

        if(playerG.transform.position.x > 0 && !disActivateCanvas)
        {
            //Play First Video
            videoPlayer1.Play();

            //Play First Vidoe's Sound
            audioSource1.Play();

            //Play First Video's Animation
            // anim.Play("FirstVideoAnim");

            //Activate Subscribe Button
            subscribeButton.SetActive(true);

            //Stop
            disActivateCanvas = true;
        }
    }

    public void subscribe()
    {
        //Destroy First Video
        Destroy(canvas1);

        //Play Second Video
        videoPlayer2.Play();

        //Play Second Video's Sound
        audioSource2.Play();

        //Play Second Video's Animation
        // anim2.Play("SecondVideoAnim");
    }

    
}
