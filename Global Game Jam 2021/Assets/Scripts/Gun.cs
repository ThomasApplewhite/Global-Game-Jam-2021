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

    protected bool canShoot = true;

    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    public virtual void Shoot()
    {
        if(canShoot)
        {
            RaycastHit hitInfo;

            bool hitLanded = Physics.Raycast(gunSource.transform.position, gunSource.transform.forward, out hitInfo, range);
            if(hitLanded)
            {
                hitInfo.transform.GetComponent<ActorHealth>()?.takeDamage(damage);
            }
            LaunchBullet(gunSource.transform.position, gunSource.transform.forward);

            StartCoroutine(cooldown(shotCooldown));
        }

    }

    protected IEnumerator cooldown(float coolTime)
    {
        var oldRot = gunSource.transform.localRotation;
        gunSource.transform.localRotation = Quaternion.Euler(-15f, 0f, 0f);
        canShoot = false;
        yield return new WaitForSeconds(coolTime);
        canShoot = true;
        gunSource.transform.localRotation = oldRot;
    }

    protected void LaunchBullet(Vector3 launchPosition, Vector3 launchDiection)
    {
        float bulletSpeed = 1000f;

        var bulletRotation = Quaternion.FromToRotation(Vector3.up, transform.forward);
        var bullet = Instantiate(projectilePrefab, launchPosition, bulletRotation);
        bullet.GetComponent<Bullet>().launcher = this.gameObject;
        bullet.GetComponent<Rigidbody>().AddForce(launchDiection * bulletSpeed, ForceMode.Impulse);
    }
}
