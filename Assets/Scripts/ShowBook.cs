using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBook : MonoBehaviour
{

    public GameObject book;
    public float[] coverColor = new float[3];
    public SpriteRenderer bookRenderer;
    AudioSource audioSource;

    public static bool BookOn;

    public Sprite[] pages;
    public int maxPage;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
    }
    private void OnMouseDown()
    {
        if (BookOn == false && SettingPageManager.GamePaused == false)
        {
            StartCoroutine(Bookinstant(book));
            BookOn = true;
        }
        
    }

    private IEnumerator Bookinstant(GameObject book)
    {
        audioSource.Play();
        book = Instantiate(book) as GameObject;
        book.GetComponent<BookManager>().pages = pages;
        book.GetComponent<BookManager>().maxPage = maxPage;
        bookRenderer = book.transform.Find("BookCover").GetComponent<SpriteRenderer>();
        bookRenderer.material.color = new Color(coverColor[0]/255f, coverColor[1]/255f, coverColor[2]/255f);
        yield return new WaitForSeconds(1f);
        //book.GetComponent<BookManager>().bookEnabled = true;
    }
}
