using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageDetect : MonoBehaviour
{
    public string direction;
    public bool rightPageClicked;
    public bool leftPageClicked;
    public GameObject book;

    private void Awake()
    {
        rightPageClicked = false;
        leftPageClicked = false;
    }

    private void OnMouseDown()
    {
        if (book.GetComponent<PageTurner>().bookEnabled == true)
        {
            if (direction == "right" && rightPageClicked == false)
            {
                rightPageClicked = true;
            }

            else if (direction == "left" && leftPageClicked == false)
            {
                leftPageClicked = true;
            }
        }

    }
}
