using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class flight : MonoBehaviour
{
    //movement
    public float forwardSpeed;
    Rigidbody2D RocketBody;
    public float MaxSpeed;

    //mouse pull code
    private Vector2 currMousePosition;
    private Vector2 currentForwardVector;
    private Quaternion endRotation;
    private Vector2 newForwardVector;
    public float mousePullStrength;
    
    // Start is called before the first frame update
    void Start()
    {
        RocketBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //moving forwards
        RocketBody.velocity += new Vector2(transform.up.x, transform.up.y)  * forwardSpeed * Time.deltaTime;
        currMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Debug.Log(RocketBody.velocity.magnitude);
        //cap speed
        if(RocketBody.velocity.magnitude > MaxSpeed)
        {
            RocketBody.velocity = RocketBody.velocity.normalized * MaxSpeed;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Splitrocket>().Split();
        }
    }

    void FixedUpdate()
    {
        //turning code
        currentForwardVector = transform.rotation * Vector3.up;

        /*endRotation = Quaternion.FromToRotation(Vector3.up, new Vector3(currMousePosition.x, currMousePosition.y, 0) - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, endRotation, Time.deltaTime * mousePullStrength);*/

        
    }
}
