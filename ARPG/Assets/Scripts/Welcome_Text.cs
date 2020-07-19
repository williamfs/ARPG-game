using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Welcome_Text : MonoBehaviour
{
    // Start is called before the first frame update
    [TextArea][SerializeField] string _welcome;
    void Start()
    {
        
    }
    public string Welcome()
    {
        return _welcome;
    }
    // Update is called once per frame
  
}
