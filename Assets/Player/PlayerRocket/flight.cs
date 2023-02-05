using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class flight : MonoBehaviour
{
    //movement
    public float launchSpeed;
    Rigidbody2D RocketBody;
    public float MaxSpeed;

    //mouse pull code
    private Vector2 currMousePosition;
    private Vector2 currentForwardVector;
    private Quaternion endRotation;
    private Vector2 newForwardVector;
    public float mousePullStrength;
    float maxFuelSeconds = 5f;
    float fuelSecondsRemaining;
    
    // Start is called before the first frame update
    void Start()
    {
        RocketBody = GetComponent<Rigidbody2D>();
        fuelSecondsRemaining = maxFuelSeconds;

        print("SETTING VELOCITY IN START");
        //Launch(new Vector2(transform.up.x, transform.up.y) * launchSpeed);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Splitrocket>().Split();
        }
    }

    void FixedUpdate()
    {
        fuelSecondsRemaining -= Time.fixedDeltaTime;
        if (fuelSecondsRemaining <= 0f)
        {

        }
        else
        {
            //turning code
            currentForwardVector = transform.rotation * Vector3.up;

            // Rotation code
            Vector2 moveVec = RocketBody.velocity.normalized;
            if (moveVec != Vector2.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveVec, Vector3.back);
                transform.Rotate(Vector3.right, 90f, Space.Self);
            }

            if (RocketBody.velocity.magnitude > MaxSpeed)
            {
                RocketBody.velocity = RocketBody.velocity.normalized * MaxSpeed;
            }
        }
    }


    public void Launch(Vector2 inVelocity)
    {
        RocketBody.velocity = inVelocity;
    }

    public void AddFuel(float inTimeToAdd)
    {
        fuelSecondsRemaining = Mathf.Clamp(fuelSecondsRemaining + inTimeToAdd, 0f, maxFuelSeconds);
    }
}
