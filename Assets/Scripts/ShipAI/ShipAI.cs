using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAI : MonoBehaviour, IDamageable {

    public int Hull { get { return hull; } set { hull = value; } }
    public int Shield { get { return shield; } set { shield = value; } }
    public int MaxHull { get { return maxHull; } set { maxHull = value; } }
    public int MaxShield { get { return maxShield; } set { maxShield = value; } }
    public float ShieldAbsorbtion { get { return shieldAbsorbtion; } set { shieldAbsorbtion = value; } }

    [SerializeField]
    public int hull;
    [SerializeField]
    public int shield;

    [SerializeField]
    public int maxHull;
    [SerializeField]
    public int maxShield;

    [Range(0, 1)]
    public float shieldAbsorbtion;

    GameObject destroyExplosion;

    void Awake()
    {
        destroyExplosion = Resources.Load("Effects/ShipExplosion") as GameObject;
    }

    public void Damage(int amount)
    {
        if(shield > 0)
        {
            shield -= amount;
            hull -= (int)(amount * (1 - shieldAbsorbtion));
            if(shield < 0)
            {
                shield = 0;
            }
        }
        else
        {
            hull -= amount;
        }

        if(hull <= 0)
        {
            DestroyCurrent();
        }
    }

    public void DestroyCurrent()
    {
        Instantiate(destroyExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
