using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManagerScript: MonoBehaviour
{

    [Header("BluePrint List :")]
    public Levels[] BP_List;

    [Header("Room Settings")]
    private int NumberOfRooms = 3;
    public List<Room> RoomList;

    [System.Serializable]
    public class Levels
    {
        public BluePrintSO[] BP;
        // public int lvl;
        public GameObject room;
        public GameObject console;
    }
    [System.Serializable]
    public class Room
    {
        public GameObject room;
        public BluePrintSO question;

        public Transform door;
        public ConsoleScript console;

        public Room(GameObject _room, BluePrintSO _question)
        {
            room = _room;
            question = _question;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        RoomList = new List<Room>();
        NumberOfRooms = BP_List.Length;
        var x_pos = 0;

        for (int i = 0; i < NumberOfRooms; i++)
        {
            var room = BP_List[i].room;
            int len = BP_List[i].BP.Length;
            var console = room.transform.Find("Console");

       
            BluePrintSO Question = BP_List[i].BP[Random.Range(0, len)];
            var ConsoleScript = console.GetComponent<ConsoleScript>();
            ConsoleScript.BPS = Question;
            RoomList.Add(new Room(room, Question));
            Instantiate(room).transform.position = new Vector3(x_pos += -16, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
