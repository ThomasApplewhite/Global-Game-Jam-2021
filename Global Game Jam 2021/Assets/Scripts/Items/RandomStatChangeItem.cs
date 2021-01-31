using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStatChangeItem : Item
{
    public string name = "Circle of Confoundination";
    public float rangeIntensity = 2f;
    
    //shot speed, move speed, damage
    public override StatObject Effect()
    {
        return new StatObject(
            name,
            Random.Range(0.05f, rangeIntensity) / 5,
            Random.Range(0.05f, rangeIntensity),
            Random.Range(0.05f, rangeIntensity)
        );
    }
}
