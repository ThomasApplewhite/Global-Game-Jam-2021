using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirerateUpItem : Item
{
    public string name = "Globe of SLAT SLAT SLAT SLAT SLAT SLAT SLAT SLAT SLAT SLAT SLAT SLAT";
    public float firerateIncrease = 0.2f;
    
    //shot speed, move speed, damage
    public override StatObject Effect()
    {
        return new StatObject(
            name,
            firerateIncrease,
            0f,
            0f
        );
    }
}
