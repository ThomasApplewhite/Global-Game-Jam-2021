using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    public List<Transform> spreadSources;
    public Transform centerSpreadSource;
    public float spreadDeviation = 10f;

    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    public override void Shoot()
    {
        if(canShoot)
        {
            foreach(Transform source in spreadSources)
            {
                RaycastHit hitInfo;

                Vector3 launchVector;

                launchVector = source.forward;

                /*if(source == centerSpreadSource)
                {
                    launchVector = source.forward;
                }
                else
                {
                    ///rotate towards with clamp
                    //var vec = source.forward;
                    //source.localRotation = 
                    //    Quaternion.RotateTowards(source.localRotation, centerSpreadSource.localRotation, Mathf.Deg2Rad * -spreadDeviation);
                    //clamp
                    //vec = Vector3.ClampMagnitude(vec, spreadDeviation);
                    //invert
                    //vec *= -1;
                    //save*
                    //var vec = Quaternion.LookRotation(centerSpreadSource.forward, Vector3.up);
                    //vec = Quaternion.Inverse(vec);
                    var rot = Vector3.RotateTowards(source.position, centerSpreadSource.position, -spreadDeviation, 0.0f);
                    rot = Vector3.ClampMagnitude(rot, spreadDeviation);
                    Debug.Log(rot);

                    launchVector = rot;
                }*/

                bool hitLanded = Physics.Raycast(source.position, launchVector, out hitInfo, range);
                if(hitLanded)
                {
                    hitInfo.transform.GetComponent<ActorHealth>()?.takeDamage(damage);
                }
                LaunchBullet(source.position, launchVector);
            }

            StartCoroutine(cooldown(shotCooldown));
        }
    }
}

/*
RaycastHit hitInfo;

            bool hitLanded = Physics.Raycast(gunSource.transform.position, gunSource.transform.forward, out hitInfo, range);
            if(hitLanded)
            {
                hitInfo.transform.GetComponent<ActorHealth>()?.takeDamage(damage);
            }
            LaunchBullet(gunSource.transform.forward);

            StartCoroutine(cooldown(shotCooldown));
*/