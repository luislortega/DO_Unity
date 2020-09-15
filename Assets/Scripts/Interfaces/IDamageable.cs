using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable {

    int Hull { get; set; }
    int Shield { get; set; }

    int MaxHull { get; set; }
    int MaxShield { get; set; }

    float ShieldAbsorbtion { get; set; }
    void Damage(int amount);
    void DestroyCurrent();
}
