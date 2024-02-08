using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject player; // Reference to the Player GameObject
    public Vector3 offset; // Offset from the player's position

    // Start is called before the first frame update
    void Start()
    {
        // If you want, you can initialize the offset here
        // For example, to have a slight rightwards and upwards offset you might use something like this:
        offset = new Vector3(3.0f, 0.0f, 0); // Adjust the values as needed
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Set the position of this GameObject to the player's position plus the offset
            // Assuming you want the camera or follower to maintain its original Z position
            Vector3 targetPosition = player.transform.position + offset;
            targetPosition.z = transform.position.z; // Keep original Z position
            transform.position = targetPosition;
        }
    }
}
