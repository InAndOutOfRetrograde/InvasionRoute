using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class flight : MonoBehaviour
{
    //movement
    public float forwardSpeed = 10f;
    Rigidbody2D RocketBody;

    //mouse pull code
    private Vector2 currMousePosition;
    private Vector2 currentForwardVector;
    private Quaternion endRotation;
    private Vector2 newForwardVector;
    public float mousePullStrength = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        RocketBody= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //moving forwardss
        RocketBody.transform.position += transform.up * forwardSpeed * Time.deltaTime;
        currMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        //turning code
        currentForwardVector = transform.rotation * Vector3.up;
        endRotation = Quaternion.FromToRotation(Vector3.up, new Vector3(currMousePosition.x, currMousePosition.y, 0) - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, endRotation, Time.deltaTime * mousePullStrength);
    }
}
