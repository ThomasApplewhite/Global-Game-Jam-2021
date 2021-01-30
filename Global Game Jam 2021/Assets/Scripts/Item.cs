using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        var player = col.gameObject.GetComponent<PlayerScript>();
        if(player)
        {
            player.ApplyItem(this);
            Destroy(this.gameObject);
        }
    }

    public abstract StatObject Effect();
}
