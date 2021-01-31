using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStatChangeItem : Item
{
    public string name = "Circle of Confoundination";
    public float rangeIntensity = 20f;
    
    //shot speed, move speed, damage
    public override StatObject Effect()
    {
        return new StatObject(
            name,
            Random.Range(0.05f, rangeIntensity) / 10,
            Random.Range(0.05f, rangeIntensity),
            Random.Range(0.05f, rangeIntensity)
        );
    }
}
