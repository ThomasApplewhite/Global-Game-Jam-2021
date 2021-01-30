using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Image deathScreen;
    public Text messageText;

    Gun gun;
    BasicPlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        gun = this.gameObject.GetComponent<Gun>();
        controller = this.gameObject.GetComponent<BasicPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootEvent(InputAction.CallbackContext context)
    {
        gun.Shoot();
    }

    public void ApplyItem(Item item)
    {
        var statChange = item.Effect();

        //speed change
        controller.movementSpeed += statChange.movementSpeedChange;

        //shooting speed change
        gun.shotCooldown -= statChange.shootingSpeedChange;

        //damage change
        gun.damage += statChange.damageChange;

        //message change
        messageText.text = "You picked up " + statChange.adjustmentName;
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

    public void DoActorDamageEffect()
    {
        StartCoroutine(screenBlip());
    }

    IEnumerator screenBlip()
    {
        var oldColor = deathScreen.color;

        deathScreen.color = new Color(
            deathScreen.color.r,
            deathScreen.color.g,
            deathScreen.color.b,
            0.6f
        );
        Debug.Log("Oofoff");

        yield return new WaitForSeconds(.5f);

        deathScreen.color = oldColor;
    }
}
