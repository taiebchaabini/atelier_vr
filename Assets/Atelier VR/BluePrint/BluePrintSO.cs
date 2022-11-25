using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Customs/Question", order = 1)]
public class BluePrintSO : ScriptableObject
{
    public string Title; 
    [System.Serializable]
    public class RepClass
    {
        public string Answer;
        public bool is_right = false;
        public GameObject model;
        public Material mat;

        public Transform position;

        private Transform obj;

        public Transform GetBluePrint ()
        {
            obj = Instantiate(model).transform;
            return obj;
        }
    }
     public RepClass[] list;
     public RepClass rep;
     public string rewrite ()
    {
        return Title.Replace("&", "[" + rep.Answer + "]");
    }

    
}
