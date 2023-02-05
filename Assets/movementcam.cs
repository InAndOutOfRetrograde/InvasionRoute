using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementcam : MonoBehaviour
{
    bool toggle = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if(toggle == true)
            {
                GetComponent<CinemachineVirtualCamera>().Priority = 11;
                toggle = false;
            }
            else
            {
                GetComponent<CinemachineVirtualCamera>().Priority = 9;
                toggle = true;
            }
        }
        if (Input.GetKey(KeyCode.W) == true)
        {
            GetComponent<CinemachineVirtualCamera>().transform.position += new Vector3(0, .3f, 0);
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            GetComponent<CinemachineVirtualCamera>().transform.position += new Vector3(0, -.3f, 0);

        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            GetComponent<CinemachineVirtualCamera>().transform.position += new Vector3(-.3f, 0, 0);

        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            GetComponent<CinemachineVirtualCamera>().transform.position += new Vector3(.3f, 0, 0);

        }
    }
}
