using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject launcher;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject != launcher)
        {
            Debug.Log("bulletgone to " + col.gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
