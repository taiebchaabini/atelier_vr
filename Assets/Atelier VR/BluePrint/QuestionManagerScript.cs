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

    [System.Serializable]
    public class Levels
    {
        public BluePrintSO[] BP;
        // public int lvl;
        // public GameObject console;
        public GameObject console;
        public Transform door;

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
            int len = BP_List[i].BP.Length;

            BluePrintSO Question = BP_List[i].BP[Random.Range(0, len)];
            var ConsoleScript = console.GetComponent<ConsoleScript>();
            ConsoleScript.BPS = Question;
            RoomList.Add(new Console(console, Question));

            // foreach (var q in Question.list)
            // {
            //     var obj = Instantiate(card);
            //     obj.transform.SetParent();
            //     obj.transform.position = Vector3.zero;
            
            // }

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
