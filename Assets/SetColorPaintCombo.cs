using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorPaintCombo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] paintedObjects;

    void Start()
    {
        //Set the color of the the sprite renderer to the mixed color of all the colors in the array
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //First color
        Color mixedColor = paintedObjects[0].GetComponent<SpriteRenderer>().color;
        //Mix all the colors
        for (int i = 1; i < paintedObjects.Length; i++)
        {
            mixedColor = MixColors(mixedColor, paintedObjects[i].GetComponent<SpriteRenderer>().color);
        }
        //Set the color of the sprite renderer
        spriteRenderer.color = mixedColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function that mixes two colors together
    public Color MixColors(Color colorA, Color colorB)
    {
        // Mix the colors by averaging their RGBA values
        Color mixedColor = (colorA + colorB) * 0.5f;
        return mixedColor;
    }
}
