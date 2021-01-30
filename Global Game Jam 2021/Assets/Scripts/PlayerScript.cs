using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Image deathScreen;

    Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        gun = this.gameObject.GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootEvent(InputAction.CallbackContext context)
    {
        gun.Shoot();
    }

    public void DoActorDeath()
    {
        deathScreen.color = new Color(
            deathScreen.color.r,
            deathScreen.color.g,
            deathScreen.color.b,
            1.0f
        );
    }
}
