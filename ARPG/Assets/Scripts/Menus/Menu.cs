using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu<T> : Menu where T : Menu<T>
{
    public static T instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Open()
    {
        if (LevelManager.instance != null)
        {
            LevelManager.instance.OpenMenu(instance);
        }
    }
}

public  class Menu : MonoBehaviour
{
    public virtual void OnBackPressed()
    {
        LevelManager.instance.CloseMenu();
    }

}
