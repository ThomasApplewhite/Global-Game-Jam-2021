using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayManager : MonoBehaviour
{
    public List<GameObject> possibleRooms;
    public Transform receivingAnchor;
    public Transform givingAnchor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/

    public void SetupHallway(Transform doorPosition)
    {
        //actually first make the new room
        var room = possibleRooms[(int)Random.Range(0f, possibleRooms.Count - 1f)];
        GameObject newRoom = Instantiate(room, new Vector3(0, -100, 0), Quaternion.identity);
        GameObject roomDoor = 
            newRoom.GetComponent<RoomManager>().Doors[
                (int)Random.Range(0f, newRoom.GetComponent<RoomManager>().Doors.Count - 1f)];
        Transform roomDoorAnchor = roomDoor.transform.GetChild(0);

        roomDoorAnchor.parent = null;
        newRoom.transform.parent = roomDoorAnchor;

        roomDoorAnchor.position = givingAnchor.position;
        roomDoorAnchor.rotation = givingAnchor.rotation;
        roomDoorAnchor.Rotate(new Vector3(0, 180, 0));

        roomDoor.transform.Translate(new Vector3(0 -10, 0));

        newRoom.transform.parent = this.gameObject.transform;
        roomDoorAnchor.parent = roomDoor.transform;

        //first, move hallway so recivingAnchor is on the provided position
        //how? make anchor the parent lol

        receivingAnchor.transform.parent = null;
        this.gameObject.transform.parent = receivingAnchor;

        receivingAnchor.transform.position = doorPosition.position;
        //receivingAnchor.transform.LookAt(doorPosition, Vector3.up);
        receivingAnchor.transform.rotation = doorPosition.rotation;
        receivingAnchor.transform.Rotate(new Vector3(0, 180, 0));
        
        this.gameObject.transform.parent = null;
        receivingAnchor.transform.parent = this.gameObject.transform;

        //finally unparent the room
        newRoom.transform.parent = null;

    }
}
