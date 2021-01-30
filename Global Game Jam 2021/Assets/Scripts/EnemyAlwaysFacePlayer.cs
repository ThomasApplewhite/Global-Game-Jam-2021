using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlwaysFacePlayer : MonoBehaviour
{
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //how to make this not look up
        this.gameObject.transform.LookAt(player, Vector3.up);
        //this.gameObject.transform.rotation = Quaternion.Euler(0, this.gameObject.transform.rotation.y, 0);
    }
}
