using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInteractions: MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "killer")
        {
            GetComponent<Miscellaneous>().DestroyMe();
        }
        if (collision.gameObject.tag == "bounce")
        {

        }
        if(collision.gameObject.tag == "diggable")
        {

        }
        else
        {
            Debug.Log("BALLS");
        }
    }
}
    
