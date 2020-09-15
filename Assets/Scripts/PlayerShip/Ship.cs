using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour, IDamageable {

    public int Hull { get { return hull; } set { hull = value; } }
    public int Shield { get { return shield; } set { shield = value; } }
    public int MaxHull { get { return maxHull; } set { maxHull = value; } }
    public int MaxShield { get { return maxShield; } set { maxShield = value; } }
    public float ShieldAbsorbtion { get { return shieldAbsorbtion; } set { shieldAbsorbtion = value; } }

    public int hull;
    public int shield;

    public int maxHull;
    public int maxShield;

    [Range(0, 1)]
    public float shieldAbsorbtion;

    public void Damage(int amount)
    {
        
    }

    public void DestroyCurrent()
    {
        
    }
}
