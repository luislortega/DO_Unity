using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clasa derivata din "QItem" care pastreaza proprietatile tuturor Itemelor care stocheaza munitite laser\\
public class QLaserAmmo : QItem {

    public Transform thinSalvo;
    public Transform thickSalvo;
    public Transform thinLF3Salvo;
    public Transform thickLF3Salvo;

    ShipWeapons _shipWeapons;
    public override void Use()
    {
        _shipWeapons = playerShip.GetComponent<ShipWeapons>();
        if (!_shipWeapons._shooting)
        {
            _shipWeapons.laserSalvo = thinSalvo;
            _shipWeapons.StartLaserAttack();
        }
        else { _shipWeapons.StopLaserAttack(); }
    }
}
