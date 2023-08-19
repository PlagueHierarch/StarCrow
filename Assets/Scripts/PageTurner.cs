using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PageTurner : MonoBehaviour
{
    //������ �ѱ�� �ִϸ��̼� ������ ������
    public Animator pageAnim;
    public bool bookEnabled;
    public GameObject LeftPage;
    public GameObject RightPage;

    private string dir;

    //ȿ���� ����� ������
    public AudioClip bookClose;
    public AudioClip pageTurn;
    string Type;

    AudioSource audioSource;
    public SpriteRenderer pageSprite;

    public Sprite[] pages;
    public int maxPage;
    public int curPage = 0;
    bool pagefind = false;

    public int BookNo;
    private void Awake()
    {
        bookEnabled = true;
        audioSource = GetComponent<AudioSource>();

        pageAnim = GameObject.Find("Bookpages").GetComponent<Animator>();
        RightPage = GameObject.Find("RightPage");
        LeftPage = GameObject.Find("LeftPage");
        pageSprite = transform.Find("Page").GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        pageSprite.sprite = pages[curPage];
    }

    // Update is called once per frame
    void Update()
    {
        if (pagefind == false)
        {
            RightPage = GameObject.Find("RightPage");
            LeftPage = GameObject.Find("LeftPage");
            pagefind = true;
        }
       
        if (bookEnabled == true)
        {
            //ESC �Է� �� å ������Ʈ �ı�
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine(DestroyBook());
            }

            //å �������� ���� ��� ������ �ѱ�� �ִϸ��̼� ���
            if (RightPage.GetComponent<PageDetect>().rightPageClicked == true)
            {
                if (curPage < maxPage)
                {
                    dir = RightPage.GetComponent<PageDetect>().direction;
                    StartCoroutine(TurnPage_Wait());
                }


            }

            //å ������ ���� ��� �ڷ� �ѱ�� �ִϸ��̼� ���
            if (LeftPage.GetComponent<PageDetect>().leftPageClicked == true)
            {
                if (curPage > 0)
                {
                    dir = LeftPage.GetComponent<PageDetect>().direction;
                    StartCoroutine(TurnPage_Wait());
                }


            }
        }
    }

    private IEnumerator TurnPage(string dir)
    {
        //���� ���⿡ ���� ��� �ִϸ��̼� ����
        if (dir == "right")
        {
            curPage++;
            pageAnim.Play("NextPage");
        }

        else if (dir == "left")
        {
            curPage--;
            pageAnim.Play("PrevPage");
        }

        //�ѱ� ����
        pageAnim.SetTrigger("Finish");
        yield return new WaitForSeconds(0.5f);
        pageSprite.sprite = pages[curPage];
        LeftPage.GetComponent<PageDetect>().leftPageClicked = false;
        RightPage.GetComponent<PageDetect>().rightPageClicked = false;
    }

    private IEnumerator TurnPage_Wait()
    {
        //å�� ���������� �ѱ�� ��� ����
        bookEnabled = false;
        pageSprite.sprite = null;
        //ȿ���� ���
        audioSource.clip = pageTurn;
        audioSource.Play();
        //å �ѱ�� �ִϸ��̼��� ����� ������ ���
        yield return StartCoroutine(TurnPage(dir));
        yield return new WaitForSeconds(1);
        bookEnabled = true;
    }
    private IEnumerator PlaycloseSfx()
    {
        audioSource.clip = bookClose;
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator DestroyBook()
    {
        yield return StartCoroutine(PlaycloseSfx());
        BookSwitch.BookOn = false;
        Destroy(GameObject.FindGameObjectWithTag("Book"));
    }
}
