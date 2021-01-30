using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : Item
{
    public string name = "Orb of GshNorgen";
    public float speedIncrease = 1.0f;
    
    
    public override StatObject Effect()
    {
        return new StatObject(
            name,
            0f,
            speedIncrease,
            0f
        );
    }
}
