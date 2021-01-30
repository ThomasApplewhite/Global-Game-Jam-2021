using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float speed = 3f;

    BasicPlayerController controller;
    GameObject player;
    Gun gun;
    Vector2 moveDirection;
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.gameObject.GetComponent<BasicPlayerController>();
        player = GameObject.FindWithTag("Player");
        gun = this.gameObject.GetComponent<Gun>();
        body = this.gameObject.GetComponent<Rigidbody>();

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

    public void DoActorDeath()
    {
        Destroy(this.gameObject);
    }
}

//playerBody.AddRelativeForce(new Vector3(moveInputs.x * movementSpeed * Time.deltaTime, 0, moveInputs.y * movementSpeed * Time.deltaTime), ForceMode.Impulse);