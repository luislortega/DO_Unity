using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSalvo : MonoBehaviour {

    [HideInInspector]
    public Vector2 target;
    [HideInInspector]
    public float distanceToTarget;

    void Start()
    {
        float angle = Utils.AngleDiff(Vector2.right, (Vector3)target - transform.position);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

	void Update () {
        float step = (distanceToTarget / 0.15f) * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        if(transform.position == (Vector3)target)
        {
            Destroy(gameObject);
        }
	}
}
