using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFadeOut : MonoBehaviour {

    public float fadeOutIntensity;

    void Start()
    {
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        for (float f = 1f; f >= 0; f -= fadeOutIntensity)
        {
            Color c = GetComponent<SpriteRenderer>().color;
            c.a = f;
            GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
        Destroy(gameObject);
    }
}
