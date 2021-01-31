using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public Image deathScreen;
    public TextMeshPro messageText;

    public TextMeshPro damageText;
    public TextMeshPro firedelayText;
    public TextMeshPro speedText;
    public TextMeshPro healthText;

    Gun gun;
    BasicPlayerController controller;
    ActorHealth health;

    // Start is called before the first frame update
    void Start()
    {
        gun = this.gameObject.GetComponent<Gun>();
        controller = this.gameObject.GetComponent<BasicPlayerController>();
        health = this.gameObject.GetComponent<ActorHealth>();

        damageText.text = "Damage: " + gun.damage;
        firedelayText.text = "Fire Delay: " + gun.shotCooldown;
        speedText.text = "Speed: " + controller.movementSpeed;
        healthText.text = "Health: " + health.currentHealth;
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/

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
        damageText.text = "Damage: " + gun.damage;
        firedelayText.text = "Fire Delay: " + gun.shotCooldown;
        speedText.text = "Speed: " + controller.movementSpeed;

        StartCoroutine(messageClear());
    }

    public void DoActorDeath()
    {
        deathScreen.color = new Color(
            deathScreen.color.r,
            deathScreen.color.g,
            deathScreen.color.b,
            1.0f
        );

        controller.enabled = false;
        messageText.text = "You are now Aliven't.";
    }

    public void DoActorDamageEffect()
    {
        StartCoroutine(screenBlip());
        healthText.text = "Health: " + health.currentHealth;
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

    IEnumerator messageClear()
    {
        yield return new WaitForSeconds(3f);
        messageText.text = "";
    }
}
