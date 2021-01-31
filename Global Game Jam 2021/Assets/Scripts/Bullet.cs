using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject launcher;

    void Start()
    {
        StartCoroutine(coolKil());
    }

    IEnumerator coolKil()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject != launcher)
        {
            Destroy(this.gameObject);
        }
    }
}
