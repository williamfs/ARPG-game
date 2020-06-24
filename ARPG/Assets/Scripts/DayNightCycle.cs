using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] float cycleSpeed = 2;
    public Light2D light2D;

    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        light2D.intensity -= Time.deltaTime * cycleSpeed;
        if (light2D.intensity <= 0 || light2D.intensity >= 1)
        {
            cycleSpeed *= -1;
        }
    }
}
