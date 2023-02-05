using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    GameObject[] planet = new GameObject[] { };
    GameObject[] goalPlanets = new GameObject[] { };
    int points;
    // Start is called before the first frame update
    void Start()
    {
        GravityAttractor[] gravityAttractors = FindObjectsOfType<GravityAttractor>();


        foreach (GravityAttractor thisLilGuy in gravityAttractors)
        {
            planet.SetValue(thisLilGuy.gameObject, 0);
        }
        foreach(GameObject planetGuy in planet)
        {
            if(planetGuy.tag == "diggable")
            {
                goalPlanets.SetValue(planetGuy.gameObject, 0);
            }
        }
    }

    public void AddPoint()
    {
        points++;
    }
    // Update is called once per frame
    void Update()
    {
        if(points == goalPlanets.Length)
        {
            Debug.Log("HEY I WON. :D");
        }
    }
}
