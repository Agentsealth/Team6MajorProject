using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;

    public Queue<string> sentences;

    public List<string> banterSentences;

    public Animator animator;

    public int index;

    public bool inChat = false;

    public int special1TextFile;

    public int special2TextFile;


    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        inChat = true;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void BanterDialogue(Dialogue dialogue, int banterIndex)
    {
        animator.SetBool("IsOpen", true);
        inChat = true;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            banterSentences.Add(sentence);
        }
        index = banterIndex;
        StartCoroutine(TypeBanterSentence(banterSentences[index]));

    }

    public void BanterDialogueSentence()
    {      
        if (sentences.Count == 0 || string.IsNullOrEmpty(banterSentences[index + 1]))
        {
            dialogueText.text = " ";
            EndDialogue();
            inChat = false;
            return;
        }      
    }

    public void BanterEndSentence()
    {
            dialogueText.text = " ";
            animator.SetBool("IsOpen", false);
            EndDialogue();
            inChat = false;
    }

    public void DisplayNextSentence()
    {
        string sentence = sentences.Dequeue();
        if(sentences.Count == 0 || string.IsNullOrEmpty(sentence))
        {
            EndDialogue();
            inChat = false;
            return;
        }

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeBanterSentence(string sentence)
    {
        dialogueText.text = " ";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;           
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = " ";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);

    }
}
