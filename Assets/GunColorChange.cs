using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunColorChange : MonoBehaviour
{
    // Reference to the Renderer component of the gun
    public Renderer gunRenderer;

    // The new color that the gun will change to
    public Color newGunColor = Color.blue;

    // Minimum height at which the player must be above the obstacle to be considered as "on top"
    public float minimumHeightAboveObstacle = 1.0f;

    // Function that changes the gun's color with the given color
    public void ChangeGunColor(Color newColor)
    {
        if (gunRenderer != null && newColor != gunRenderer.material.color)
        {
            //If gun is white, change to new color
            if (gunRenderer.material.color == Color.white)
            {
                gunRenderer.material.color = newColor;
            } else
            {
                // Mix the current color with the new color
                Color mixedColor = MixColors(gunRenderer.material.color, newColor);
                // Change the color of the gun
                gunRenderer.material.color = mixedColor;
            }
        }
    }

    // Function that mixes two colors together
    public Color MixColors(Color colorA, Color colorB)
    {
        // Mix the colors by averaging their RGBA values
        Color mixedColor = (colorA + colorB) * 0.5f;
        return mixedColor;
    }

    // Unity's method that is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object collided with is tagged as "Obstacle"
        Debug.Log("Collision detected");
        if (collision.gameObject.CompareTag("Paint") || (collision.gameObject.CompareTag("EnemyWeak"))) 
        {
            // Assuming your player's "feet" are at the bottom of the collider, 
            // you can check if the collision contact point is below the center of the player
            if ((collision.gameObject.CompareTag("EnemyWeak")) || collision.contacts[0].point.y < (transform.position.y - GetComponent<Collider2D>().bounds.extents.y))
            {
                // Call the function to change the gun's color
                Debug.Log("Changing color");
                Debug.Log(collision.gameObject.GetComponent<SpriteRenderer>().color.ToString());
                ChangeGunColor(collision.gameObject.GetComponent<SpriteRenderer>().color);

                // Destroy the obstacle
                Destroy(collision.gameObject);
            }
        }
    }
}
