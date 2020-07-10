using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UIElements;

public class Light_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] double Timer = 0.1;
    [SerializeField] Light2D PlayerLight;
    [SerializeField] Transform LightBar;
    [SerializeField] float total_Bateries = 2f;
    [SerializeField] TextMeshProUGUI Batery_text;
    
    double counter = 1f;
    bool lightOn = false;
    bool lock_corutine = false;
    void Start()
    {
        PlayerLight = GetComponent<Light2D>();
        Batery_text.text = total_Bateries.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        keyPressed();
        StartLight();
        CheckBateries();
 
    }
    private void keyPressed()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            lightOn = !lightOn;
        }
    }
    private void StartLight()
    {
        if(lightOn&&counter>0)
        {
            PlayerLight.pointLightOuterRadius = 10;
            counter -= Time.deltaTime * Timer;
            LightBar.transform.localScale = new Vector2((float)counter, 1f);
        }
        else if(lightOn==false)
        {
            PlayerLight.pointLightOuterRadius = 0;
        }
        else if(counter<0)
        {
            PlayerLight.pointLightOuterRadius = 0;
        }
    
    }
    private void CheckBateries()
    {
      
        if(LightBar.transform.localScale.x <=0 && lock_corutine ==false&&total_Bateries>0)
        {
            lock_corutine = true;
            StartCoroutine(RechargeBatery());
        }
    }
    IEnumerator RechargeBatery()
    {
        yield return new WaitForSeconds(3f);
        LightBar.transform.localScale = new Vector2(1f,1f);
        total_Bateries--;
        lock_corutine = false;
        counter = 1f;
        Batery_text.text = total_Bateries.ToString();

    }
   
}
