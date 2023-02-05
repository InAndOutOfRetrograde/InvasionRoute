using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    private Transform myTransform;
    int tries = 3;
    [SerializeField] GameObject PlayerRocket;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
    }

    public void LookAtMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - myTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //angle that the weapon must rotate around
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        myTransform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        if (Input.GetMouseButtonDown(0) == true && tries > 0)
        {
            GameObject newRocket = Instantiate(PlayerRocket, transform.position,Quaternion.identity);
            newRocket.transform.up = transform.up;
            tries--;
        }
    }
}
