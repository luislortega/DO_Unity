using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    public float speed;
    public Transform lasersPos;
    public Ship shipScript;
    public ShipWeapons shipWeaponsScript;
    public Sprite[] rotationStates;

    void Awake()
    {
        shipScript = GetComponent<Ship>();
        shipWeaponsScript = GetComponent<ShipWeapons>();
    }

    void Start()
    {
        _clickedSpot = transform.position;
    }

    Vector3 _clickedSpot;
    [HideInInspector] public bool _isMovingByMouseHold;
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            if(Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.gameObject.CompareTag("MovementSurface"))
                {
                    _clickedSpot = hit.point;
                    _isMovingByMouseHold = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit, 100f))
            {
                _isMovingByMouseHold = false;
            }
        }
        SetRotation();
        Move(_clickedSpot);
    }

    //Misca nava catre punctul 'spotPos'\\
    void Move(Vector3 spotPos)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, spotPos, step);
    }

    //Seteaza imaginea de rotatie a navei si rotatia laserelor orientata catre vectorul de pozitie 'point'\\
    void SetRotation()
    {
        float degPerState = 360 / 32;

            if (!shipWeaponsScript._shooting)
            {
                if (_isMovingByMouseHold)
                {
                    float angle = Utils.AngleDiff(Vector2.right, _clickedSpot - transform.position);
                    int state = (int)(angle / degPerState);
                    GetComponent<SpriteRenderer>().sprite = rotationStates[state];
                    lasersPos.transform.eulerAngles = new Vector3(0, 0, angle);
                }
            }
            else
            {
                Vector2 shootingTarget = shipWeaponsScript.targetToShoot.position;

                float angle = Utils.AngleDiff(Vector2.right, shootingTarget - (Vector2)transform.position);
                int state = (int)(angle / degPerState);
                GetComponent<SpriteRenderer>().sprite = rotationStates[state];
                lasersPos.transform.eulerAngles = new Vector3(0, 0, angle);
            }
    }
}
