using System.Collections;
using System.Collections.Generic;
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
        if (gammaSlider.value < 0.02 && book4on == true)
        {
            Debug.Log("Change sprite");
            showBook.pages[0] = darkPage;
            PageRenderer.sortingOrder = 6;
            GameObject oldbook = GameObject.Find("Book(Clone)");
            Destroy(oldbook);
            StartCoroutine(showBook.Bookinstant(showBook.book));
            gameObject.GetComponent<boo4dark>().enabled = false;


            /*if(BookSwitch.BookOn == true)
            {
                Debug.Log("Change sprite");
                PageRenderer = showBook.book.transform.Find("Page").GetComponent<SpriteRenderer>();
                Debug.Log(PageRenderer.sprite);
                PageRenderer.sprite = darkPage;
            }*/
        }
    }
}
