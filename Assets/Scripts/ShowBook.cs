using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBook : MonoBehaviour
{

    public GameObject book;
    public float[] coverColor = new float[3];
    public SpriteRenderer bookRenderer;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
    }
    private void OnMouseDown()
    {
        StartCoroutine(Bookinstant(book));
    }

    private IEnumerator Bookinstant(GameObject book)
    {
        audioSource.Play();
        book = Instantiate(book) as GameObject;
        bookRenderer = book.transform.GetComponent<SpriteRenderer>();
        bookRenderer.material.color = new Color(coverColor[0]/255f, coverColor[1]/255f, coverColor[2]/255f);
        yield return new WaitForSeconds(2f);
        //book.GetComponent<BookManager>().bookEnabled = true;
    }
}
