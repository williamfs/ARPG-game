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

    private Collision2D person;

    int Index = 0;
    int total_count;
    string Dialoge;
    bool start = false;
    void Start()
    {
        Text_As_GO.SetActive(false);
          
        
    }

    // Update is called once per frame
    void Update()
    {
        Something.text = Dialoge;
        if (start == true)
        {
            Dialoge = person.gameObject.GetComponent<Dialogues>().Return_Dialogues(Index);
            Debug.Log(Index);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Dialoge = collision.gameObject.GetComponent<Dialogues>().Return_Dialogues(Index);
        if (collision.gameObject.tag == "villager")
        {


            Text_As_GO.SetActive(true);
            person = collision;
            total_count = collision.gameObject.GetComponent<Dialogues>().TotalString() - 1;
            start = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        start = false;
        Index = 0;
        Text_As_GO.SetActive(false);
    }

    public void  NextNumber()
    {
        if (Index<total_count) {
            Index++;
          
        }
        else
        {
            Text_As_GO.SetActive(false);
        }
    }
}
