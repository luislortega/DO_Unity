using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour {

    [HideInInspector] public IDamageable structure;
    public Image hullBar;
    public Image shieldBar;

    void LateUpdate()
    {
        Utils.FillBar(hullBar, structure.Hull, structure.MaxHull);
        Utils.FillBar(shieldBar, structure.Shield, structure.MaxShield);
        if(structure.Shield <= 0)
        {
            if (shieldBar.transform.parent.gameObject.activeSelf)
            {
                shieldBar.transform.parent.gameObject.SetActive(false);
            }
        }
        else
        {
            if (!shieldBar.transform.parent.gameObject.activeSelf)
            {
                shieldBar.transform.parent.gameObject.SetActive(true);
            }
        }
    }
}
