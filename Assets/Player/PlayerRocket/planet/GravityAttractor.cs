using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    [SerializeField] float gravitationalForce = 1f;

    List<Rigidbody2D> gravityAttractedRBs;
    float myTrueGravityRadius;

    // Start is called before the first frame update
    void Start()
    {
        gravityAttractedRBs = new List<Rigidbody2D>();
        myTrueGravityRadius = transform.lossyScale.x * GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Rigidbody2D thisRB in gravityAttractedRBs)
        {
            Vector2 myPos2D = new Vector2(transform.position.x, transform.position.y);
            Vector2 otherPos2D = new Vector2(thisRB.transform.position.x, thisRB.transform.position.y);
            float distBetweenUs = Vector2.Distance(myPos2D, otherPos2D);
            float linearPullPercent = Mathf.Clamp01((myTrueGravityRadius - distBetweenUs) / myTrueGravityRadius);
            float linearPullPercentSquared = Mathf.Pow(linearPullPercent, 2f);
            //print(linearPullPercent);

            thisRB.velocity = thisRB.velocity + (myPos2D - otherPos2D).normalized * linearPullPercentSquared;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<GravityAttracted>())
        {
            gravityAttractedRBs.Add(collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<GravityAttracted>())
        {
            gravityAttractedRBs.Remove(collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }
}
