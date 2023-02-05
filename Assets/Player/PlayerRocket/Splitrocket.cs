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
            RocketBody.rotation += 45;
            GameObject DupliRocket = GameObject.Instantiate(Rocket, transform.position, Quaternion.identity);
            DupliRocket.GetComponent<Splitrocket>().duplicationAmount -= 1;
            duplicationAmount -= 1;
            DupliRocket.GetComponent<Rigidbody2D>().rotation -= 45;
        }
    }
}
