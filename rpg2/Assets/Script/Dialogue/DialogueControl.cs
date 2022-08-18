using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt
    }

    public idiom language;

    [Header("Componentes")]
    public GameObject dialogueObj;
    public Image profileSprite;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;

    private bool isShowing;
    private int index;
    private string[] sentences;
    Sprite[] sprites;
    string[] actorName;

    public static DialogueControl instance;

    private Player player;

    public bool IsShowing { get => isShowing; set => isShowing = value; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
                profileSprite.sprite = sprites[index];
                actorNameText.text = actorName[index];
            } else
            {
                cleanDialogue();
            }
        }
    }

    public void Speech(string[] txt, Sprite[] spr, string[] nameTxt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            sprites = spr;
            actorName = nameTxt;
            StartCoroutine(TypeSentence());
            profileSprite.sprite = sprites[index];
            actorNameText.text = actorName[index];
            isShowing = true;
            player.CanWalk = false;
        }
    }

    public void cleanDialogue()
    {
        speechText.text = "";
        index = 0;
        dialogueObj.SetActive(false);
        sentences = null;
        isShowing = false;
        player.CanWalk = true;
    }
}
