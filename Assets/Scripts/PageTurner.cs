using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PageTurner : MonoBehaviour
{
    //페이지 넘기는 애니메이션 관리용 변수들
    public Animator pageAnim;
    public bool bookEnabled;
    public GameObject LeftPage;
    public GameObject RightPage;

    private string dir;

    //효과음 재생용 변수들
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
            //ESC 입력 시 책 오브젝트 파괴
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine(DestroyBook());
            }

            //책 오른쪽을 누를 경우 앞으로 넘기는 애니메이션 재생
            if (RightPage.GetComponent<PageDetect>().rightPageClicked == true)
            {
                if (curPage < maxPage)
                {
                    dir = RightPage.GetComponent<PageDetect>().direction;
                    StartCoroutine(TurnPage_Wait());
                }


            }

            //책 왼쪽을 누를 경우 뒤로 넘기는 애니메이션 재생
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
        //누른 방향에 따라 출력 애니메이션 변동
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

        //넘김 종료
        pageAnim.SetTrigger("Finish");
        yield return new WaitForSeconds(0.5f);
        pageSprite.sprite = pages[curPage];
        LeftPage.GetComponent<PageDetect>().leftPageClicked = false;
        RightPage.GetComponent<PageDetect>().rightPageClicked = false;
    }

    private IEnumerator TurnPage_Wait()
    {
        //책을 연속적으로 넘기는 경우 방지
        bookEnabled = false;
        pageSprite.sprite = null;
        //효과음 재생
        audioSource.clip = pageTurn;
        audioSource.Play();
        //책 넘기는 애니메이션이 종료될 때까지 대기
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
