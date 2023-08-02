using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController : MonoBehaviour
{
    // Mouse Controls the player
    public float moveSpeed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        // Get the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get the direction the player should face
        Vector3 direction = mousePos - transform.position;

        // Get the angle the player should face
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the player
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Move towards the mouse
        transform.position = Vector2.MoveTowards(transform.position, mousePos, moveSpeed * Time.deltaTime);   
    }
}
