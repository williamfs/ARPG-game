using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Experimental.GlobalIllumination;


public class Electricity_Controler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player player;
   

    float totalPieces;
    float Pieces_Required = 3f;
    private bool activate=false;
    private bool Activate_Light = false;
    private bool OneTimeActivate = false;
    void Start()
    {
        totalPieces = player.Get_TotalElectricPieces();

      
    }

    // Update is called once per frame
    
    void Update()
    {
       
        totalPieces = player.Get_TotalElectricPieces();
        if (Input.GetKeyDown(KeyCode.X) && totalPieces == Pieces_Required)
        {
            Activate_Light = true;
            OneTimeActivate = true;
            Get_Activatelight();
           
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            activate = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            activate = false;
        }
    }
    public bool Get_Activatelight()
    {
        return Activate_Light;
    }
}
