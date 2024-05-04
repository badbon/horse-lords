using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController : MonoBehaviour
{
    // Mouse Controls the player
    public float moveSpeed = 5f;
    public float rotationClamp = 70f;
    public Vector3 mousePos;
    public bool canFireSpear = true;
    public GameObject spearObject;
    public float spearTimer = 0.5f;
    public float health = 10f;

    public void FireSpear()
    {
        if(canFireSpear)
        {
            canFireSpear = false;
            GameObject spear = Instantiate(spearObject, transform.position, transform.rotation);
            spear.GetComponent<Spear>().horse = this;
            StartCoroutine(ResetFireSpear());
        }
    }

    public IEnumerator ResetFireSpear()
    {
        yield return new WaitForSeconds(spearTimer);
        canFireSpear = true;
    }

    public void Knockback(float knockback, float knockbackAngle, Vector3 position)
    {
        Debug.Log("Knockback");
        Vector2 difference = transform.position - position;
        difference = difference.normalized * knockback;
        GetComponent<Rigidbody2D>().AddForce(difference, ForceMode2D.Impulse);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Debug.Log("Horse is dead. rip horse.");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Get the mouse position
        mousePos = Input.mousePosition;
        mousePos.z = 10; // select distance = 10 units from the camera
        Vector3 movePoint = Camera.main.ScreenToWorldPoint(mousePos);

        // Move player towards the mouse
        transform.position = Vector2.MoveTowards(transform.position, movePoint, moveSpeed * Time.deltaTime);

        // Rotate player towards the mouse
        Vector3 difference = movePoint - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        // Clamp rotation
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Clamp(rotationZ, -rotationClamp, rotationClamp));

        // Fire spear projectile
        if (Input.GetMouseButtonDown(0))
        {
            FireSpear();
        }
    }
}
