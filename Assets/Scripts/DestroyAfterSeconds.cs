using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float lifeTime = 0.5f;

    void Start()
    {
        StartCoroutine(DestroyAfterSecondsCoroutine());
    }
    
    public IEnumerator DestroyAfterSecondsCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
