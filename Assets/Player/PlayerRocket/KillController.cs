using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillController : MonoBehaviour
{
    void DestroyMe()
    {
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("space"))
        {
            DestroyMe();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "killer")
        {
            DestroyMe();
        }
        if (collision.gameObject.tag == "bounce")
        {

        }
        if(collision.gameObject.tag == "diggable")
        {

        }
    }
}
    
