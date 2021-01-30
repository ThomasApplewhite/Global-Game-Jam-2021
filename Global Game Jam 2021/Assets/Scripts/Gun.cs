using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEngine.Physics;

public class Gun : MonoBehaviour
{
    public GameObject gunSource;
    public GameObject projectilePrefab;
    public float damage = 10f;
    public float range = 100f;
    public float shotCooldown = 1f;
    public int shotAmount = 9;

    bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if(canShoot)
        {
            RaycastHit hitInfo;

            bool hitLanded = Physics.Raycast(gunSource.transform.position, gunSource.transform.forward, out hitInfo, range);
            if(hitLanded)
            {
                hitInfo.transform.GetComponent<ActorHealth>()?.takeDamage(damage);
            }
            //LaunchBullet();

            StartCoroutine(cooldown(shotCooldown));
        }

    }

    IEnumerator cooldown(float coolTime)
    {
        canShoot = false;
        yield return new WaitForSeconds(coolTime);
        canShoot = true;
    }

    /*void LaunchBullet()
    {
        Instantiate()
    }*/
}
