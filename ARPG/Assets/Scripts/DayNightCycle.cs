using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] float cycleSpeed = 2;
    private Light2D light2D;
    public bool cycle = true; // Will be call in other scripts when some kind of events happen

    // Start is called before the first frame update
    void Awake()
    {
        light2D = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cycle)
        {
            light2D.intensity -= Time.deltaTime * cycleSpeed;
            if (light2D.intensity <= 0 || light2D.intensity >= 1)
            {
                cycleSpeed *= -1;
            }
        }
    }
}
