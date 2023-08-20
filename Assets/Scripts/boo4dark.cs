using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class boo4dark : MonoBehaviour
{
    public Slider gammaSlider;
    public bool book4on;
    public Sprite darkPage;

    public SpriteRenderer PageRenderer;
    ShowBook showBook;

    private void Awake()
    {
        showBook = gameObject.GetComponent<ShowBook>();
    }

    private void Start()
    {
        PageRenderer = showBook.book.transform.Find("Page").GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        if(SettingPageManager.GamePaused == false)
        {
            //Debug.Log("book 4 on");
            book4on = true;
        }
        
    }
    void Update()
    {
        if (gammaSlider.value < 0.5 && book4on == true)
        {
            //Debug.Log("Change sprite");
            Time.timeScale = 1f;
            showBook.pages[0] = darkPage;
            showBook.sortingOrder = 7;
            PlayerPrefs.SetInt("darkPage", 1);
            if (BookSwitch.BookOn == true)
            {
                if (GameObject.FindGameObjectWithTag("Book").GetComponent<PageTurner>().BookNo == 4)
                {
                    Destroy(GameObject.FindGameObjectWithTag("Book"));
                    StartCoroutine(showBook.Bookinstant(showBook.book));
                }

            }
            gameObject.GetComponent<boo4dark>().enabled = false;

        }
    }
}
