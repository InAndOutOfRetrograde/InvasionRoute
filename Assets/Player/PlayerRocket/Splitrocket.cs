using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Splitrocket : MonoBehaviour
{

    Rigidbody2D RocketBody;
    Vector3 mainEndRotation;
    Quaternion duplicateEndRotation;
    public float duplicationAmount = 1;
    [SerializeField] GameObject Rocket;
    // Start is called before the first frame update
    void Start()
    {
        RocketBody = this.gameObject.GetComponent<Rigidbody2D>();
    }
    public void Split()
    {
        if (duplicationAmount > 0)
        {
            mainEndRotation = Quaternion.AngleAxis(45, RocketBody.transform.up) * RocketBody.transform.up;
            RocketBody.velocity = Rotate(RocketBody.velocity, 45f);

            GameObject dupliRocket = GameObject.Instantiate(Rocket, transform.position, transform.rotation);
            dupliRocket.GetComponent<Splitrocket>().duplicationAmount -= 1;
            duplicationAmount -= 1;
            //Rigidbody2D dupliRocketRB = DupliRocket.GetComponent<Rigidbody2D>();
            //print("Setting the velocity in SplitRocket");
            //dupliRocketRB.velocity = Rotate(RocketBody.velocity, -90f);
            if (dupliRocket.GetComponent<flight>()) print("FOUND!!!!!!!!!!!!!!");
            dupliRocket.GetComponent<Rigidbody2D>().velocity = (Rotate(RocketBody.velocity, -90f));
        }
    }



    // Code from https://answers.unity.com/questions/661383/whats-the-most-efficient-way-to-rotate-a-vector2-o.html
    Vector2 Rotate(Vector2 v, float degrees)
    {
        float radians = degrees * Mathf.Deg2Rad;
        float sin = Mathf.Sin(radians);
        float cos = Mathf.Cos(radians);

        float tx = v.x;
        float ty = v.y;

        return new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
    }
}
