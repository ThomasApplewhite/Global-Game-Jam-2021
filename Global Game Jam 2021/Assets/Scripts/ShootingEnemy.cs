using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class ShootingEnemy : MonoBehaviour
{
    public float speed = 3f;

    BasicPlayerController controller;
    GameObject player;
    Gun gun;
    Vector2 moveDirection;
    Rigidbody body;
    SpriteRenderer image;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.gameObject.GetComponent<BasicPlayerController>();
        player = GameObject.FindWithTag("Player");
        gun = this.gameObject.GetComponent<Gun>();
        body = this.gameObject.GetComponent<Rigidbody>();
        image = this.gameObject.GetComponent<SpriteRenderer>();

        moveDirection = Vector2.zero;

        //StartCoroutine(Attack());
        ChangeMovement();
    }

    // Update is called once per frame
    void Update()
    {
        gun.Shoot();
        body.AddRelativeForce(new Vector3(moveDirection.x * speed, 0, moveDirection.y * speed), ForceMode.Impulse);
    }

    void ChangeMovement()
    {
        var pPos = player.transform.position;
        var oPos = this.gameObject.transform.position;

        //for now let's just pick a random direction
        moveDirection = new Vector2(
            Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f)
        );

        StartCoroutine(movementTime(1.5f));
    }

    IEnumerator movementTime(float moveTime)
    {
        yield return new WaitForSeconds(moveTime);
        ChangeMovement();
    }

    public void DoActorDamageEffect()
    {
        StartCoroutine(colorTime(0.05f));
    }

    public void DoActorDeath()
    {
        Destroy(this.gameObject);
    }

    IEnumerator colorTime(float time)
    {
        Color old = image.color;
        image.color = Color.white;
        yield return new WaitForSeconds(time);
        image.color = old;
    }
}

//playerBody.AddRelativeForce(new Vector3(moveInputs.x * movementSpeed * Time.deltaTime, 0, moveInputs.y * movementSpeed * Time.deltaTime), ForceMode.Impulse);