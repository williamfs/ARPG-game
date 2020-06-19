using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogues : MonoBehaviour
{
    // Start is called before the first frame update
    [TextArea] [SerializeField] string[] Dialogue;
    public string Return_Dialogues(int index)
    {
        return Dialogue[index];
    }
    public int TotalString()
    {
        return Dialogue.Length;
    }
  
}
