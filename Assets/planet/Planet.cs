using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    bool hasBeenHit;
    [SerializeField] float amtOfFuelToAdd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "killer")
        {
            Destroy(collision.gameObject);
        }
        flight flightScript = collision.gameObject.GetComponent<flight>();

        if (flightScript != null)
        {
            hasBeenHit = true;
            flightScript.AddFuel(amtOfFuelToAdd);
            FindObjectOfType<GameManage>().AddPoint();
        }
    }
}
