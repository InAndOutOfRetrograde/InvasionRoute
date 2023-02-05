using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlanetSpawn : MonoBehaviour
{
    [SerializeField] Sprite planet1;
    [SerializeField] Sprite planet2;
    [SerializeField] Sprite planet3;
    [SerializeField] Sprite planet4;

    int randomNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(0, 3);
        if(randomNum > 2)
        {
            
        }
        else
        {
            tag = "killer";
        }
        Sprite[] planetSprites = new Sprite[] { planet1, planet2, planet3, planet4 };
        GetComponent<SpriteRenderer>().sprite = planetSprites[randomNum];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
