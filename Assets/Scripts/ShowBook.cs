using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBook : MonoBehaviour
{

    public GameObject book;
    public float[] coverColor = new float[3];
    public SpriteRenderer bookRenderer;
    AudioSource audioSource;

    public Sprite[] pages;
    public int maxPage;

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

    private IEnumerator Bookinstant(GameObject book)
    {
        audioSource.Play();
        book = Instantiate(book) as GameObject;
        book.GetComponent<PageTurner>().pages = pages;
        book.GetComponent<PageTurner>().maxPage = maxPage;
        bookRenderer = book.transform.Find("BookCover").GetComponent<SpriteRenderer>();
        bookRenderer.material.color = new Color(coverColor[0]/255f, coverColor[1]/255f, coverColor[2]/255f);
        yield return new WaitForSeconds(1f);
        //book.GetComponent<BookManager>().bookEnabled = true;
    }

}
