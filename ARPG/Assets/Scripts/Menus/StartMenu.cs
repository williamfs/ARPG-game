using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : Menu<StartMenu>
{
    public void OnStartPressed()
    {
        LevelManager.instance.LoadNextLevel();


    }

    public void OnOptionPressed()
    {

    } 

    public void OnCreditPressed()
    {
        //LevelManager.instance.OpenMenu(CreditMenu.instance);
        CreditMenu.Open();
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }

    public override void OnBackPressed()
    {
        base.OnBackPressed();
    }


}
