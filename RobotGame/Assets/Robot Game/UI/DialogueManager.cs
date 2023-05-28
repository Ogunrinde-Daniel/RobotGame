using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject continueButton;

    public Image leftImage;
    public Image rightImage;

    public Animator DialogueBoxAnimator;
    public Animator DialogueImagesAnimator;

    private Queue<string> sentences;
    private Queue<bool> leftSides;
    private Queue<string> names;

    public  float letterDelay = 0.01f;
    public  float SentenceDelay = 0.01f;


    public bool dialogueOn = false;
    void Start()
    {
        sentences = new Queue<string>();
        leftSides = new Queue<bool>();
        names = new Queue<string>();

    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueOn = true;
        DialogueBoxAnimator.SetBool("IsOpen", true);
        DialogueImagesAnimator.SetBool("IsOpen", true);

        names.Clear();
        leftSides.Clear();
        sentences.Clear();

        
        foreach (SentenceStruct sentenceStruct in dialogue.sentenceStruct)
        {
            names.Enqueue(sentenceStruct.name);
            leftSides.Enqueue(sentenceStruct.leftSide);
            sentences.Enqueue(sentenceStruct.sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        continueButton.GetComponent<Button>().interactable = false;
        string sentence = sentences.Dequeue();
        nameText.text = names.Dequeue();
        switchCharacterSide(leftSides.Dequeue());
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            if (letter.CompareTo('.') == 0)
            {
                yield return new WaitForSeconds(SentenceDelay);
            }
            else
            {
                yield return new WaitForSeconds(letterDelay);

            }

        }
        continueButton.GetComponent<Button>().interactable = true;
    }

    public void SkipDialogue()
    {
        EndDialogue();
    }


    void EndDialogue()
    {
        dialogueOn = false;
        DialogueBoxAnimator.SetBool("IsOpen", false);
        DialogueImagesAnimator.SetBool("IsOpen", false);
    }

    void switchCharacterSide(bool leftSide)
    {
        if (leftSide)
        {
            nameText.alignment = TextAlignmentOptions.TopLeft;
            dialogueText.alignment = TextAlignmentOptions.TopLeft;
            //reset opacity of the current side
            Color imageColor = leftImage.color;
            imageColor.a = 1f;
            leftImage.color = imageColor;
            //reduce opacity of the other side
            imageColor = rightImage.color;
            imageColor.a = 0.5f;
            rightImage.color = imageColor;
        }
        else
        {
            nameText.alignment = TextAlignmentOptions.TopRight;
            dialogueText.alignment = TextAlignmentOptions.TopRight;

            //reset opacity of the current side
            Color imageColor = rightImage.color;
            imageColor.a = 1f;
            rightImage.color = imageColor;
            //reduce opacity of the other side
            imageColor = leftImage.color;
            imageColor.a = 0.5f;
            leftImage.color = imageColor;
        }

    }


}
