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
    public float onTime2;

    public float fontSize;

    public static bool bubbleOn;
    private bool typeOn = false;
    Coroutine coroutine;

    public GameObject dialoguepos;

    public GameObject DialogueManager;
    public int obj;
    public int scriptNo;
    public string dialogue;

    private void Awake()
    {
        bubbleOn = false;
        canvasGroup = SpeechBubble.GetComponent<CanvasGroup>();
        onTime2 = onTime;
    }

    private void Update()
    {
        if(typeOn && Input.GetMouseButtonDown(0))
        {
            onTime2 = onTime - 2;
            StopCoroutine(coroutine);
            textmesh.text = dialogue;
            typeOn = false;
        }
    }
    private void OnMouseDown()
    {
        if (bubbleOn == false && SettingPageManager.GamePaused == false && BookSwitch.BookOn == false)
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
        var bubble = Instantiate(SpeechBubble, dialoguepos.transform.position, transform.rotation, GameObject.FindGameObjectWithTag("Canvas").transform);
        textmesh = bubble.transform.GetComponentInChildren<TextMeshProUGUI>();
        canvasGroup = bubble.GetComponent<CanvasGroup>();
        dialogue = DialogueManager.GetComponent<JsonParsing>().line.Dialogues[obj].Dialogue[scriptNo].text;
        textmesh.fontSize = fontSize;
        textmesh.text = dialogue;
        coroutine = StartCoroutine(Typing());
        yield return new WaitForSeconds(0.5f);
        Debug.Log("1 " + onTime);
        Debug.Log("2 " + onTime2);
        if (onTime2 < onTime) yield return new WaitForSeconds(onTime2);
        else yield return new WaitForSeconds(onTime);
        onTime2 = onTime;
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

            if(!typeOn && i >= 1) typeOn = true;
        }

        typeOn = false;
    }
}
