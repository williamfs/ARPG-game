using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Life_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite[] heart_Sprites;


    SpriteRenderer HeartRender;

    int counter = 0;
    int totalSprites;
    bool Corutine_lock = false;
    void Start()
    {
        totalSprites = heart_Sprites.Length;
        HeartRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
  public void StartCicle()
    {
        StartCoroutine(HeartCicle());
    }
    IEnumerator HeartCicle()
    {
       

        yield return new WaitForSeconds(2f);

        if (counter < totalSprites)

        {
            HeartRender.sprite = heart_Sprites[counter];
            counter++;
        }

    }
    public void HeartChanger()
    {
        if (counter < totalSprites)

        {
            HeartRender.sprite = heart_Sprites[counter];
            counter++;
        }
    }
}
