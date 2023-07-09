using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
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

    private void Awake()
    {
        bookEnabled = true;
        RightPage = GameObject.Find("RightPage");
        LeftPage = GameObject.Find("LeftPage");

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
 

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
                dir = RightPage.GetComponent<PageDetect>().direction;
                StartCoroutine(TurnPage_Wait());

            }

            //å ������ ���� ��� �ڷ� �ѱ�� �ִϸ��̼� ���
            if (LeftPage.GetComponent<PageDetect>().leftPageClicked == true)
            {
                dir = LeftPage.GetComponent<PageDetect>().direction;
                StartCoroutine(TurnPage_Wait());

            }
        }
        

    }

    private IEnumerator TurnPage_Wait()
    {
        //å�� ���������� �ѱ�� ��� ����
        bookEnabled = false;
        //ȿ���� ���
        audioSource.clip = pageTurn; 
        audioSource.Play();
        //å �ѱ�� �ִϸ��̼��� ����� ������ ���
        yield return StartCoroutine(TurnPage(dir));
        bookEnabled = true;
        yield return new WaitForSeconds(1);
    }

    private IEnumerator TurnPage(string dir)
    {
        //���� ���⿡ ���� ��� �ִϸ��̼� ����
        if (dir == "right")
        {
            pageAnim.Play("NextPage");
        }

        else if (dir == "left")
        {
            pageAnim.Play("PrevPage");
        }

        //�ѱ� ����
        pageAnim.SetTrigger("Finish");
        yield return new WaitForSeconds(1);
        LeftPage.GetComponent<PageDetect>().leftPageClicked = false;
        RightPage.GetComponent<PageDetect>().rightPageClicked = false;
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
        Destroy(GameObject.FindGameObjectWithTag("Book"));
    }
}
