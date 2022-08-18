using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerMask;

    public DialogueSettings dialogue;

    bool playerHit;
    DialogueControl dialControl;

    private List<string> sentences = new List<string> ();
    List<Sprite> spr = new List<Sprite>();
    List<string> actorName = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        GetNPCInfo();
        dialControl = DialogueControl.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            dialControl.Speech(sentences.ToArray(), spr.ToArray(), actorName.ToArray());
        }
    }

    private void FixedUpdate()
    {
        ShowDialogue();
    }

    void GetNPCInfo()
    {
        for(int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.instance.language)
            {
                case DialogueControl.idiom.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;
            }
            spr.Add(dialogue.dialogues[i].profile);
            actorName.Add(dialogue.dialogues[i].actorName);
        }
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerMask);
        if (hit != null)
            playerHit = true;
        else
            playerHit = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
