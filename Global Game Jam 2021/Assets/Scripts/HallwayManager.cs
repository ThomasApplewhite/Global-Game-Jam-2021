using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayManager : MonoBehaviour
{
    public List<GameObject> possibleRooms;
    public Transform receivingAnchor;
    public Transform givingAnchor;

    public static int hallmake = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/

    public void SetupHallway(Transform doorPosition, Transform startPosition)
    {
        ++HallwayManager.hallmake;

        //actually first make the new room
        var roomPick = (int)Random.Range(0f, possibleRooms.Count - 1f);
        Debug.Log("Generating room " + roomPick);
        var room = possibleRooms[roomPick]; //startPosition.position.x, startPosition.position.z
        GameObject newRoom = Instantiate(room, new Vector3(0, -200, 0), Quaternion.identity);
        GameObject roomDoor = 
            newRoom.GetComponent<RoomManager>().Doors[
                (int)Random.Range(0f, newRoom.GetComponent<RoomManager>().Doors.Count - 1f)];
        Transform roomDoorAnchor = roomDoor.transform.GetChild(0);
        //the first room is now generated

        //return;

        //setup anchor parantage
        roomDoorAnchor.parent = null;
        newRoom.transform.parent = roomDoorAnchor;

        //rotate to face givingAnchor
        var newRot = Quaternion.LookRotation(givingAnchor.position, Vector3.up);
        newRot.x = 0;
        newRot.z = 0;
        roomDoorAnchor.rotation = newRot;

        //it might still end up backwards...
        //https://answers.unity.com/questions/1010169/how-to-know-if-an-object-is-looking-at-an-other.html
        //basically, this determines some stuff with vectors. If it's 1, then they're looking exactly at each other
        /*Vector3 dirFromAtoB = (receivingAnchor.transform.position - doorPosition.position).normalized;
        float dotProd = Vector3.Dot(dirFromAtoB, doorPosition.forward);

        Debug.Log(dotProd);*/

        //attach to givingAnchor
        roomDoorAnchor.position = givingAnchor.position;

        var dist = Vector3.Distance(newRoom.transform.position, this.gameObject.transform.position);
        Debug.Log("Distance of Room and Hall: " + dist);

        //if the hallway and the room are too close, that means the room needs to be flipped
        if(dist < 45f)
        //nice
        {
            Debug.Log("turning around new room...");
            //translate forward
            //well backward because according to unity the receivingAnchor is on the back
            roomDoorAnchor.transform.Translate(roomDoorAnchor.transform.forward * 200, Space.World);

            //turn around?
            newRot = Quaternion.LookRotation(givingAnchor.position * -1, Vector3.up);
            newRot.x = 0;
            newRot.z = 0;
            roomDoorAnchor.transform.rotation = newRot;
            //attach to givingAnchor
            roomDoorAnchor.position = givingAnchor.position;
        }

        //open the door to the new room
        roomDoor.transform.Translate(new Vector3(0, -10, 0), Space.World);

        //remove it from the door list so it can't be used to make a new room
        newRoom.GetComponent<RoomManager>().Doors.Remove(roomDoor);

        //parent shenanigans
        newRoom.transform.parent = this.gameObject.transform;
        roomDoorAnchor.parent = roomDoor.transform;

        //first, move hallway so recivingAnchor is on the provided position
        //how? make anchor the parent lol

        receivingAnchor.transform.parent = null;
        this.gameObject.transform.parent = receivingAnchor;
        Debug.Log(doorPosition.position);
        //look at anchor
        newRot = Quaternion.LookRotation(doorPosition.position, Vector3.up);
        Debug.Log("Hallway Rotation angle: " + newRot.y);
        newRot.x = 0;
        newRot.z = 0;
        receivingAnchor.transform.rotation = newRot;

        //slot into place
        /*if(HallwayManager.hallmake < 2)
        {
            
        }*/
        receivingAnchor.transform.position = doorPosition.position;
        Debug.Log("Final Hallway Rotation: " + receivingAnchor.transform.rotation.y);
        

        //finally unparent the room
        newRoom.transform.parent = null;

        //https://answers.unity.com/questions/1010169/how-to-know-if-an-object-is-looking-at-an-other.html
        //basically, this determines some stuff with vectors. If it's 1, then they're looking exactly at each other
        //Vector3 dirFromAtoB = (receivingAnchor.transform.position - doorPosition.position).normalized;
        //float dotProd = Vector3.Dot(dirFromAtoB, doorPosition.forward);

        //Debug.Log(dotProd);

        //this whole correction thing isn't needed anymore
        //if it's facing the correct way...
        /*if(false)
        {
            //translate forward
            //well backward because according to unity the receivingAnchor is on the back
            receivingAnchor.transform.Translate(receivingAnchor.transform.forward * -100, Space.World);

            newRot = Quaternion.LookRotation(doorPosition.position * -1, Vector3.up);
            newRot.y = 0;
            receivingAnchor.transform.rotation = newRot;
            receivingAnchor.transform.Rotate(new Vector3(0, 180, 0));

            //turn around?
            newRot = Quaternion.LookRotation(doorPosition.position * -1, Vector3.up);
            newRot.y = 0;
            receivingAnchor.transform.rotation = newRot;
            receivingAnchor.transform.Rotate(new Vector3(0, 180, 0));

        
        }*/
        //if it isn't the forward-and-turn-around setp can be skipped because it's already facing that way
        
        

    }
}
