using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpItem : Item
{
    public string name = "Sphere of KhykKhykKhyk";
    public float damageIncrease = 1.0f;
    
    //shot speed, move speed, damage
    public override StatObject Effect()
    {
        return new StatObject(
            name,
            0f,
            0f,
            damageIncrease
        );
    }
}
