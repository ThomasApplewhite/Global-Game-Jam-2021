using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : MonoBehaviour
{
    private ActorHealth health;

    // Start is called before the first frame update
    void Start()
    {
        health = this.gameObject.GetComponent<ActorHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoActorDeath()
    {
        Debug.Log("Dummy Down!");
        health.currentHealth = health.startingMaxHealth;
    }
}
