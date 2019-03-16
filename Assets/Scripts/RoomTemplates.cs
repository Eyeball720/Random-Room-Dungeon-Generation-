using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {
    /// <summary>
    /// Rooms containing a south door
    /// </summary>
    public GameObject[] southRooms;
    /// <summary>
    /// Rooms containing a North door
    /// </summary>
    public GameObject[] northRooms;
    /// <summary>
    /// Rooms containing a West door
    /// </summary>
    public GameObject[] westRooms;
    /// <summary>
    /// Rooms containing a East door
    /// </summary>
    public GameObject[] eastRooms;

    public float waitTime;
    private bool spawnedEnd;
    public GameObject end;
    private RoomArray roomArrayScript;
    private List<GameObject> rooms;

    private void Start()
    {
        roomArrayScript = GameObject.FindGameObjectWithTag("World").GetComponent<RoomArray>();
        rooms = roomArrayScript.rooms;
    }

    private void Update()
    {
        if (waitTime <= 0 && spawnedEnd == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == roomArrayScript.rooms.Count - 1)
                {
                    Instantiate(end, rooms[i].transform.position, end.transform.rotation);
                    spawnedEnd = true;
                }
            }
        }
        else if(waitTime >= 0)
        {
            waitTime -= Time.deltaTime;
        }
    }
}
