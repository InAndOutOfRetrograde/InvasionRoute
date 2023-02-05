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
    // Start is called before the first frame update
    void Start()
    {
    if (spritePick == 3)
        {
            gameObject.tag = "killer";
        }
        Sprite[] planetSprites = new Sprite[] { planet1, planet2, planet3, planet4 };
        GetComponent<SpriteRenderer>().sprite = planetSprites[spritePick];
        transform.localScale = new Vector2(planetSize, planetSize);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "killer")
        {
            Destroy(gameObject);
        }
    }
}
