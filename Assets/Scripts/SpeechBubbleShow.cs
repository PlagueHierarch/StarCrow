using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubbleShow : MonoBehaviour
{
    public GameObject SpeechBubble;
    public TextMeshProUGUI textmesh;
    public CanvasGroup canvasGroup;
    public float fadetime;
    public float onTime;

    public float fontSize;

    bool bubbleOn;

    public Vector3 offset;

    public GameObject DialogueManager;
    public int obj;
    public int scriptNo;
    public string dialogue;

    private void Awake()
    {
        bubbleOn = false;
        canvasGroup = SpeechBubble.GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        //dialogue = DialogueManager.GetComponent<JsonParsing>().line.Dialogues[obj].Dialogue[scriptNo].text;
    }
    private void OnMouseDown()
    {
        if (bubbleOn == false && SettingPageManager.GamePaused == false && ShowBook.BookOn == false)
        {
            StartCoroutine(Bubble());
        }
        
    }


    private IEnumerator fadeBubble()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / fadetime;
            //Debug.Log("bubblenalpha : " + canvasGroup.alpha);
            yield return null;
        }
        yield return new WaitForSeconds(1);

    }

    public IEnumerator Bubble()
    {
        bubbleOn = true;
        var bubble = Instantiate(SpeechBubble, gameObject.transform.position + offset, transform.rotation, GameObject.FindGameObjectWithTag("Canvas").transform);
        textmesh = bubble.transform.GetComponentInChildren<TextMeshProUGUI>();
        canvasGroup = bubble.GetComponent<CanvasGroup>();
        SpeechBubble.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        dialogue = DialogueManager.GetComponent<JsonParsing>().line.Dialogues[obj].Dialogue[scriptNo].text;
        textmesh.fontSize = fontSize;
        textmesh.text = dialogue;
        StartCoroutine(Typing());
        yield return new WaitForSeconds(onTime);
        yield return StartCoroutine(fadeBubble());
        Destroy(bubble);
        bubbleOn = false;
    }

    private IEnumerator Typing()
    {
        for (int i = 0; i <= dialogue.Length; i++)
        {
            textmesh.text = dialogue.Substring(0, i);

            yield return new WaitForSeconds(0.1f);
        }

    }
}
