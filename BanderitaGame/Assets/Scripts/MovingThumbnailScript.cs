using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingThumbnailScript : MonoBehaviour
{

    Rigidbody2D rb;

    bool isGoingLeft = true;

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
    

    // Set Player Child Of The Thumbnail To Make The Player Following Thumbnail
    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
    }
}
