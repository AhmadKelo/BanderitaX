using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingThumbnailScript : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField] bool isGoingLeft = true;

    bool start = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(WaitForThumbnail());
    }

    void FixedUpdate()
    {
        if (!start)
        {
            if (isGoingLeft)
            {
                transform.position += new Vector3(-0.1f, 0, 0);
            }
            else if (!isGoingLeft)
            {
                transform.position += new Vector3(0.1f, 0, 0);
            }
        }
    }


    IEnumerator WaitForThumbnail()
    {
        if (start)
        {
            yield return new WaitForSeconds(Random.Range(0f,2f));
            start = false;

        }else if(!start)
        { 
            yield return new WaitForSeconds(1.8f);
            isGoingLeft = !isGoingLeft;

        }

        StartCoroutine(WaitForThumbnail());

    }
}
