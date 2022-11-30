using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManagerScript: MonoBehaviour
{

    [Header("BluePrint List :")]
    public Levels[] BP_List;

    [Header("Room Settings")]
    private int NumberOfRooms = 3;
    public List<Console> RoomList;
    public GameObject card;
    public Transform card_position;

    [System.Serializable]
    public class Levels
    {
        public BluePrintSO[] BP;
        // public int lvl;
        // public GameObject console;
        public GameObject console;
        public Transform door;
        public GameObject[] cards;

    }
    [System.Serializable]
    public class Console
    {
        public GameObject console;
        public BluePrintSO question;

        // public ConsoleScript script;

        public Console(GameObject _console, BluePrintSO _question)
        {
            console = _console;
            question = _question;
        }
    }

    private void Awake() {
        RoomList = new List<Console>();
        NumberOfRooms = BP_List.Length;
        // var x_pos = 0;

        for (int i = 0; i < NumberOfRooms; i++)
        {
            var console = BP_List[i].console;

            BluePrintSO Question = BP_List[i].BP[0];

            var ConsoleScript = console.GetComponent<ConsoleScript>();
            ConsoleScript.door = BP_List[i].door;
            ConsoleScript.BPS = Question;
            
            for (int b = 0; b <= 2; b++)
            {
                BP_List[i].cards[b].GetComponent<GrababbleAnswer>().answer.text = Question.list[b].Answer;
            }
            RoomList.Add(new Console(console, Question));
            // Instantiate(console).transform.position = new Vector3(x_pos += -16, 0, 0);
        }    
}

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
