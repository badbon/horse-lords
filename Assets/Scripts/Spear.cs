using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public HorseController horse; //Owner of the spear
    public float speed = 10f;
    public float lifeTime = 5f;
    public float damage = 10f;
    public float knockback = 10f;
    public float knockbackDuration = 0.1f;
    public float knockbackDelay = 0.05f;
    public float knockbackAngle = 90f;
    public GameObject hitEffect;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        StartCoroutine(DestroyAfterSecondsCoroutine());
    }

    public void HitPlayer()
    {
        horse.TakeDamage(damage);
        horse.Knockback(knockback, knockbackAngle, horse.transform.position);
        Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public IEnumerator DestroyAfterSecondsCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
