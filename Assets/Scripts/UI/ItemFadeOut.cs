using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFadeOut : MonoBehaviour {

    public float fadeOutIntensity;
    public GameObject icon;
    ItemsControlManager itemsControlManagerScript;
    [HideInInspector] public DragableItem origin;

    bool _hasReleasedMouse = false;
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(!_hasReleasedMouse) StartCoroutine("Fade");
            _hasReleasedMouse = true;
        }
    }

    IEnumerator Fade()
    {
        for (float f = 1f; f >= 0; f -= fadeOutIntensity)
        {
            Color c = GetComponent<Image>().color;
            c.a = f;
            GetComponent<Image>().color = c;
            yield return null;
        }
        origin._hasInstatiatedTemplate = false;
        origin._hasSentTheItem = false;
        Destroy(gameObject);
    }
}
