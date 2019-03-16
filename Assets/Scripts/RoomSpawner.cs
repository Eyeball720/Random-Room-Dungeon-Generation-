using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomSpawner : MonoBehaviour
{
    /*
     * 1 South door
     * 2 North door
     * 3 West door
     * 4 East door
     */
    public int openingDirection;
    /// <summary>
    /// CS Script contianing all of the rooms
    /// </summary>
    private RoomTemplates templates;
    private int rand;
    /// <summary>
    /// Used to check if the spawner has spawned a room
    /// </summary>
    public bool spawned = false;
    /// <summary>
    /// The dungeon parent object
    /// </summary>
    private GameObject world;
    /// <summary>
    /// The room that is being spawned
    /// </summary>
    private GameObject room;
    /// <summary>
    /// Script that contaons all of the spawned rooms in order of spawning
    /// </summary>
    private RoomArray roomArrayScript;
    /// <summary>
    /// Array of the rooms that have been spawned
    /// </summary>
    private List<GameObject> roomArray;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
        world = GameObject.FindGameObjectWithTag("World");
        roomArrayScript = world.GetComponent<RoomArray>();
        roomArray = roomArrayScript.rooms;
    }

    void Spawn()
    {
        if(spawned == false)
        {
            if (openingDirection == 1)
            {
                //spawn room with South door
                rand = Random.Range(0, templates.southRooms.Length);
                room = Instantiate(templates.southRooms[rand], transform.position, templates.southRooms[rand].transform.rotation);
                room.transform.parent = world.transform;
                roomArray.Add(room);
            }
            else if (openingDirection == 2)
            {
                //spawn room with North door
                rand = Random.Range(0, templates.northRooms.Length);
                room = Instantiate(templates.northRooms[rand], transform.position, templates.southRooms[rand].transform.rotation);
                room.transform.parent = world.transform;
                roomArray.Add(room);
            }
            else if (openingDirection == 3)
            {
                //spawn room with West door
                rand = Random.Range(0, templates.westRooms.Length);
                room = Instantiate(templates.westRooms[rand], transform.position, templates.southRooms[rand].transform.rotation);
                room.transform.parent = world.transform;
                roomArray.Add(room);
            }
            else if (openingDirection == 4)
            {
                //spawn room with East door
                rand = Random.Range(0, templates.eastRooms.Length);
                room = Instantiate(templates.eastRooms[rand], transform.position, templates.southRooms[rand].transform.rotation);
                room.transform.parent = world.transform;
                roomArray.Add(room);
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned == true)
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("StartRoomPos"))
        {
            Destroy(gameObject);
        }
    }

}

