using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInfoUIFollow : MonoBehaviour {

    public Transform shipToFollow;

	void LateUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(shipToFollow.position);
    }
}
