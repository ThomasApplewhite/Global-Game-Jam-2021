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
            LaunchBullet(gunSource.transform.forward);

            StartCoroutine(cooldown(shotCooldown));
        }

    }

    IEnumerator cooldown(float coolTime)
    {
        var oldRot = gunSource.transform.localRotation;
        gunSource.transform.localRotation = Quaternion.Euler(-30f, 0f, 0f);
        canShoot = false;
        yield return new WaitForSeconds(coolTime);
        canShoot = true;
        gunSource.transform.localRotation = oldRot;
    }

    void LaunchBullet(Vector3 launchDiection)
    {
        float bulletSpeed = 100f;

        var bulletRotation = Quaternion.FromToRotation(Vector3.up, transform.forward);
        var bullet = Instantiate(projectilePrefab, gunSource.transform.position, bulletRotation);
        bullet.GetComponent<Bullet>().launcher = this.gameObject;
        bullet.GetComponent<Rigidbody>().AddForce(launchDiection * bulletSpeed, ForceMode.Impulse);
    }
}
