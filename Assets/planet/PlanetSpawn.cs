using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class PlanetSpawn : MonoBehaviour
{
    [SerializeField] Sprite planet1;
    [SerializeField] Sprite planet2;
    [SerializeField] Sprite planet3;
    [SerializeField] Sprite planet4;

    public int spritePick;
    public float planetSize;
    float planetCollideSize;

    // Start is called before the first frame update
    void Start()
    {
        planetCollideSize = planetSize * 3;
        if (spritePick == 3)
        {
            gameObject.tag = "killer";
        }

        Sprite[] planetSprites = new Sprite[] { planet1, planet2, planet3, planet4 };
        GetComponent<SpriteRenderer>().sprite = planetSprites[spritePick];
        transform.localScale = new Vector2(planetSize, planetSize);
        transform.parent.GetChild(0).localScale = new Vector2(planetCollideSize,planetCollideSize);
    }
}
