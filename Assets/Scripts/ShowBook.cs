using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBook : MonoBehaviour
{

    public GameObject book;
    public float[] coverColor = new float[3];
    public SpriteRenderer bookRenderer;
    AudioSource audioSource;
    public SpriteRenderer PageRenderer;

    public Sprite[] pages;
    public int maxPage;
    public int sortingOrder;

    public PageTurner pageTurner;
    public int bookNo;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        if (BookSwitch.BookOn == false && SettingPageManager.GamePaused == false)
        {
            BookSwitch.BookOn = true;
            StartCoroutine(Bookinstant(book));
        }
        
    }

    public IEnumerator Bookinstant(GameObject book)
    {
        audioSource.Play();
        book = Instantiate(book) as GameObject;
        book.GetComponent<PageTurner>().pages = pages;
        book.GetComponent<PageTurner>().maxPage = maxPage;
        bookRenderer = book.transform.Find("BookCover").GetComponent<SpriteRenderer>();
        PageRenderer = book.transform.Find("Page").GetComponent<SpriteRenderer>();
        pageTurner = book.GetComponent<PageTurner>();
        pageTurner.BookNo = bookNo;
        PageRenderer.sortingOrder = sortingOrder;
        bookRenderer.material.color = new Color(coverColor[0]/255f, coverColor[1]/255f, coverColor[2]/255f);
        yield return new WaitForSeconds(1f);
        //book.GetComponent<BookManager>().bookEnabled = true;
    }

}
