using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] float cycleSpeed = 2;
    [SerializeField] TextMeshProUGUI DayLight_Text;
   

    bool night = false;
    private bool lock_update = false;
    public Light2D light2D;
    private double Incremenet = 0;

    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();
        DayLight_Text.color = new Color(1f, 1f, 1f, (float)Incremenet);
      
    }

    // Update is called once per frame
    void Update()
    {
        light2D.intensity -= Time.deltaTime * cycleSpeed;
        if (light2D.intensity <= 0 || light2D.intensity >= 1)
        {
            cycleSpeed *= -1;
            lock_update = false;
        }
        textChanger();
   
    }
    private void textChanger()
    {
     
        DayLight_Text.color = new Color(1f, 1f, 1f, (float)Incremenet);

        if (light2D.intensity <=0.5 && cycleSpeed > 0.0001 &&Incremenet <=1 &&lock_update == false)
        {
            Incremenet = Incremenet + Time.deltaTime * 0.3;
            if(Incremenet >1)
            {
                lock_update = true;
            }
           
        }
        if(lock_update )
        {
            Incremenet = Incremenet - Time.deltaTime * 0.3;
            if(Incremenet <0)
            {
                Incremenet = 0;
            }
        }
      

     
    }

}
