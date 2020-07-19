using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemosSpawnSystem : MonoBehaviour
{
    // Start is called before the first frame update\
    [SerializeField] DayNightCycle dayNight;

    private int total_ghost;
    private bool night;
    void Start()
    {
        total_ghost = transform.childCount;
        night = dayNight.Night_Controller();
        for(int i=0;i<total_ghost;i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        night = dayNight.Night_Controller();
        if(night==true)
        {
            for (int i = 0; i < total_ghost; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else if (night == false)
        {
            for (int i = 0; i < total_ghost; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
