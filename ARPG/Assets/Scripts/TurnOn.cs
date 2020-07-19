using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Electricity_Controler Controller;
    private bool activate;
    void Start()
    {
        activate = Controller.Get_Activatelight();
        
    }

    // Update is called once per frame
    void Update()
    {
        activate = FindObjectOfType<Electricity_Controler>().Get_Activatelight();

        if (activate==false)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
     else if(activate ==true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
