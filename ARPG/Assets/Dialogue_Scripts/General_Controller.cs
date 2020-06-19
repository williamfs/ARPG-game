using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class General_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI Something;
    [SerializeField] GameObject Text_As_GO;
    
    int Index = 0;
    int total_count;
    void Start()
    {

          
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string Dialoge = collision.gameObject.GetComponent<Dialogues>().Return_Dialogues(Index);
        total_count = collision.gameObject.GetComponent<Dialogues>().TotalString();
        
    }
    public void  NextNumber()
    {
        if (Index<total_count) {
            Index++;
        }
    }
}
