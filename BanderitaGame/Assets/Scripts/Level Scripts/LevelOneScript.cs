using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LevelOneScript : MonoBehaviour
{
    GameObject playerG;

    bool disActivateCanvas = false;

    GameObject canvas1;
    GameObject canvas2;

    Animator anim;
    Animator anim2;

    GameObject subscribeButton;

    VideoPlayer videoPlayer1;
    VideoPlayer videoPlayer2;

    void Start()
    {

        //Attach Video Players
        videoPlayer1 = GameObject.Find("Canvas/Video Player").GetComponent<VideoPlayer>();
        videoPlayer2 = GameObject.Find("Canvas 2/Video Player").GetComponent<VideoPlayer>();

        //Attach canvases
        canvas1 = GameObject.Find("Canvas");
        canvas2 = GameObject.Find("Canvas 2");

        //Attach player
        playerG = GameObject.Find("Player");

        //Attach Anims
        anim = canvas1.GetComponent<Animator>();
        anim2 = canvas2.GetComponent<Animator>();

        //Attach Subscribe Button
        subscribeButton = GameObject.Find("Canvas/SubscribeButton");

        //Disable Subscribe Button
        subscribeButton.SetActive(false);

        //Prepare Videos For Better Performance   
        // canvas1.GetComponent<UnityEngine.Video.VideoPlayer>().Prepare();
        // canvas2.GetComponent<UnityEngine.Video.VideoPlayer>().Prepare();

        videoPlayer1.Prepare();
        videoPlayer2.Prepare();
    }

    void Update()
    {
        if(playerG.transform.position.x > 0 && !disActivateCanvas)
        {
            //Play First Video
            // canvas1.GetComponent<UnityEngine.Video.VideoPlayer>().Play();
            videoPlayer1.Play();

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
        // canvas2.GetComponent<UnityEngine.Video.VideoPlayer>().Play();
        videoPlayer2.Play();


        //Play Second Video's Animation
        // anim2.Play("SecondVideoAnim");
    }

    
}
