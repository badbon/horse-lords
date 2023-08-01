using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseAnimator : MonoBehaviour
{
    public Sprite[] sprites;
    public bool animate = true;
    public SpriteRenderer spriteRenderer;
    public float speed = 0.05f;

    void Start()
    {
        StartCoroutine(AnimateHorse());
    }

    void Update()
    {
 
    }

    // Coroutine to animate horse from sprites
    IEnumerator AnimateHorse()
    {
        while (animate)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                spriteRenderer.sprite = sprites[i];
                yield return new WaitForSeconds(speed);
            }
        }
    }
}
