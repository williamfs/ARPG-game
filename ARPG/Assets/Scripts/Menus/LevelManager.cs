using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] Transform menuParent;

    [SerializeField] StartMenu startMenuPrefab;
    [SerializeField] CreditMenu creditMenuPrefab;

    private Stack<Menu> menuStack = new Stack<Menu>();

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Menu[] menuPrefabs =  { startMenuPrefab, creditMenuPrefab };

        foreach (Menu prefab in menuPrefabs)
        {
            Menu newMenu = Instantiate(prefab, menuParent);

            if (prefab != startMenuPrefab)
            {
                newMenu.gameObject.SetActive(false);
            }
            else
            {
                OpenMenu(newMenu);
            }
        }

    }

    public void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        currentIndex++;
        SceneManager.LoadScene(currentIndex);
    }

    public void OpenMenu(Menu menuToOpen)
    {
        // Close all the menus in the stack first
        if (menuStack.Count > 0)
        {
            foreach (Menu menu in menuStack)
            {
                menu.gameObject.SetActive(false);
            }
        }

        menuToOpen.gameObject.SetActive(true);
        menuStack.Push(menuToOpen);

        Debug.Log("Menu: " + menuStack.Peek() + " is on the top");
    }

    public void CloseMenu()
    {
        if (menuStack.Count <= 0)
        {
            Debug.Log("There are no Menus in the stack!");
            return;
        }

        Menu menuToClose = menuStack.Pop();
        menuToClose.gameObject.SetActive(false);

        if (menuStack.Count > 0)
        {
            menuStack.Peek().gameObject.SetActive(true);
        }
    }

}
