using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManagerScript: MonoBehaviour
{

    [Header("BluePrint List :")]
    public Levels[] BP_List;

    [Header("Room Settings")]
    public int NumberOfRooms = 3;
    public List<Room> RoomList;

    [System.Serializable]
    public class Levels
    {
        public BluePrintSO[] BP;
        public int lvl;
        public GameObject room;
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
        for (int i = 0; i < NumberOfRooms; i++)
        {
            int len = BP_List[i].BP.Length;
            BluePrintSO Question = BP_List[i].BP[Random.Range(0, len)];
            RoomList.Add(new Room(null, Question));    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
