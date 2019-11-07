using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;

    public Queue<string> sentences;

    public List<string> banterSentences;
    public string[] greetingSentences;
    public string[] badQualitySentences;
    public string[] neturalQualitySentences;
    public string[] bestQualitySentences;

    public Animator animator;

    public int index;

    public bool inChat = false;

    public int special1TextFile;

    public int special2TextFile;

    public TextAsset greeting;
    public TextAsset badQuality;
    public TextAsset neturalQuality;
    public TextAsset bestQuality;



    private void Start()
    {
        //Creates a new queue of strings for sentences
        sentences = new Queue<string>();
        //Splits the text file greeting for the array grettingSentences
        greetingSentences = greeting.text.Split('\n');
        //Splits the text file badQuality for the array badQualitySentences
        badQualitySentences = badQuality.text.Split('\n');
        //Splits the text file neturalQuality for the array neturalQualitySentences
        neturalQualitySentences = neturalQuality.text.Split('\n');
        //Splits the text file bestQuality for the array bestQualitySentences
        bestQualitySentences = bestQuality.text.Split('\n');
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Sets the animator bool IsOpen to true
        animator.SetBool("IsOpen", true);
        //Sets the inchat to true
        inChat = true;
        //Clears any preExisiting sentences
        sentences.Clear();
        //Foreach loop for a sentence string in dialogue sentencess
        foreach(string sentence in dialogue.sentences)
        {
            //Makes the queue for the sentences
            sentences.Enqueue(sentence);
        }
        //Runs the display next sentence function
        DisplayNextSentence();
    }

    public void BanterDialogue(Dialogue dialogue, int banterIndex)
    {
        //Sets the animator bool IsOpen to true
        animator.SetBool("IsOpen", true);
        //Sets the inchat to true
        inChat = true;
        //Clears any preExisiting sentences
        sentences.Clear();
        //Foreach loop for a sentence string in dialogue sentencess
        foreach (string sentence in dialogue.sentences)
        {
            //Adds the sentence to the list of strings
            banterSentences.Add(sentence);
        }
        //Sets the index based on the banter index
        index = banterIndex;
        //Start the coroutine TypeBanterSentence based on the index for banterSentences
        StartCoroutine(TypeBanterSentence(banterSentences[index]));
    }

    public void BanterDialogueSentence()
    {      
        //Checks if the sentence length is 0 or the banter sentence is null
        if (sentences.Count == 0 || string.IsNullOrEmpty(banterSentences[index + 1]))
        {
            //Changes the text to blank
            dialogueText.text = " ";
            //Runs the end dialogue function
            EndDialogue();
            //Changes the inchat bool to false
            inChat = false;
            return;
        }      
    }

    public void BanterEndSentence()
    {
        //Sets the text to blank
        dialogueText.text = " ";
        //Sets the animator bool IsOpen to false
        animator.SetBool("IsOpen", false);
        //Runs the function to end the dialogue
        EndDialogue();
        //Sets the inchat to false
        inChat = false;
    }

    public void DisplayNextSentence()
    {
        //Sets the string by dequeue a queue of strings
        string sentence = sentences.Dequeue();
        //Checks if the sentence length is equal to 0 or the sentence is null or empty
        if(sentences.Count == 0 || string.IsNullOrEmpty(sentence))
        {
            //Runs the function to end the dialogue
            EndDialogue();
            //Sets the inchat to false
            inChat = false;
            return;
        }
        //Stops all exisitng Coroutines
        StopAllCoroutines();
        //Starts the coroutine to type sentences for sentences
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeBanterSentence(string sentence)
    {
        //Set text to blank
        dialogueText.text = " ";
        //For each loop which check all the letters in the sentence
        foreach (char letter in sentence.ToCharArray())
        {
            //Set text to add letters
            dialogueText.text += letter;
            yield return null;           
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        //Set text to blank
        dialogueText.text = " ";
        //For each loop which check all the letters in the sentence
        foreach (char letter in sentence.ToCharArray())
        {
            //Set text to add letters
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        //Sets the animator bool IsOpen to false
        animator.SetBool("IsOpen", false);   
    }
}
