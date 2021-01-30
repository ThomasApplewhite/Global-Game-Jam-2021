using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    BasicPlayerController controller;
    GameObject player;
    Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.gameObject.GetComponent<BasicPlayerController>();
        player = GameObject.FindWithTag("Player");
        gun = this.gameObject.GetComponent<Gun>();

        //StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        gun.Shoot();
    }

    public void DoActorDeath()
    {
        Destroy(this.gameObject);
    }
}
