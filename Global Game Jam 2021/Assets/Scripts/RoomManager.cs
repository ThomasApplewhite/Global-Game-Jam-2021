using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<GameObject> Doors;
    public List<GameObject> PossibleItems;
    public List<GameObject> Enemies;

    public GameObject Hallway;

    public Transform ItemSpawnPoint;

    public int enemyCounter = 0;

    public bool roomFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        enemyCounter = Enemies.Count;

        foreach(GameObject enemy in Enemies)
        {
            enemy.AddComponent<RoomMonitor>().room = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCounter <= 0)
        {
            RoomClear();
            roomFinished = true;
        }
    }

    void RoomClear()
    {
        if(roomFinished)
        {
            return;
        }

        Debug.Log("Room Over!");

        if(PossibleItems.Count > 0)
        {
            GameObject itemToMake = PossibleItems[(int)Random.Range(0f, PossibleItems.Count - 1f)];
            Instantiate(itemToMake, ItemSpawnPoint.position, Quaternion.identity);
        }

        GameObject doorToOpen = Doors[(int)Random.Range(0f, Doors.Count - 1f)];

        GameObject hallway = Instantiate(Hallway, new Vector3(0, -100, 0), Quaternion.identity);
        hallway.GetComponent<HallwayManager>()?.SetupHallway(doorToOpen.transform.GetChild(0).transform);

        doorToOpen.transform.Translate(new Vector3(0 -10, 0));
        
    }
}

public class RoomMonitor : MonoBehaviour
{
    public RoomManager room;
    public void DoActorDeath()
    {
        room.enemyCounter -= 1;
    }
}
