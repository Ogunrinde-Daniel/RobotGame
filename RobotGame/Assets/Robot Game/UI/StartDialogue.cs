using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public int level;
    private LevelDialogues levelDialogues;
    private void Start()
    {
        levelDialogues = gameObject.AddComponent<LevelDialogues>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            levelDialogues.TriggerDialogue(level);
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            FindObjectOfType<DialogueManager>().SkipDialogue();
    }




}
