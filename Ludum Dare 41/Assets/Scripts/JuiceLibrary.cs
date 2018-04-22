using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceLibrary : MonoBehaviour
{
    public AudioSource mainSource;

    public IEnumerator BlinkRed(GameObject gameObject)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        spriteRenderer.color = new Color(255, spriteRenderer.color.g, spriteRenderer.color.b);
        yield return null;
    }

    public void PlaySound(AudioClip clip)
    {
        mainSource.PlayOneShot(clip);
    }
}
