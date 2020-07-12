using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Light2D GlobalLight;
    void Start()
    {
        GlobalLight = GetComponent<Light2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
