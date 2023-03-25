using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDialogues : MonoBehaviour
{
    private static Dialogue dialogue;

    public void TriggerDialogue(int level)
    {
        switch (level)
        {
            case 0:
                epilogueDialogue();
                break;
            case 1:
                loadLevel1Dialogue();
                break;
            case 2:
                loadLevel2Dialogue();
                break;
            case 3:
                loadLevel3Dialogue();
                break;
            case 4:
                loadLevel4Dialogue();
                break;
            default:
                loadLevel1Dialogue();
                break;

        }

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    static void loadLevel1Dialogue()
    {
        dialogue = new Dialogue();
        dialogue.sentenceStruct = new SentenceStruct[5];

        dialogue.sentenceStruct[0].leftSide = true;
        dialogue.sentenceStruct[0].name = "Alpha";
        dialogue.sentenceStruct[0].sentence = "Where am I? What happened?";

        dialogue.sentenceStruct[1].leftSide = false;
        dialogue.sentenceStruct[1].name = "Dr. Katherine";
        dialogue.sentenceStruct[1].sentence = "You're in Hyperion City, Alpha. You were blown up by a big robot named Delta";

        dialogue.sentenceStruct[2].leftSide = true;
        dialogue.sentenceStruct[2].name = "Alpha";
        dialogue.sentenceStruct[2].sentence = "Delta? Who's that?";

        dialogue.sentenceStruct[3].leftSide = false;
        dialogue.sentenceStruct[3].name = "Dr. Katherine";
        dialogue.sentenceStruct[3].sentence = "He was sent by the government to destroy you. But don't worry, I can help you.\n " +
                                                "You just need to retrieve your body parts and avoid touching enemies.";

        dialogue.sentenceStruct[4].leftSide = false;
        dialogue.sentenceStruct[4].name = "Dr. Katherine";
        dialogue.sentenceStruct[4].sentence = "Tip:: You can bounce on enemies to temporarily disable them.\n " +
                                                "Good Luck.";

    }

    static void loadLevel2Dialogue()
    {
        dialogue = new Dialogue();
        dialogue.sentenceStruct = new SentenceStruct[5];

        dialogue.sentenceStruct[0].leftSide = true;
        dialogue.sentenceStruct[0].name = "Alpha";
        dialogue.sentenceStruct[0].sentence = "Why did Delta(the big robot) blow me up?";

        dialogue.sentenceStruct[1].leftSide = false;
        dialogue.sentenceStruct[1].name = "Dr. Katherine";
        dialogue.sentenceStruct[1].sentence = "You were an experimental robot and were starting to become sentient.\n " +
                                                "The government saw you as a threat and sent to destroy you.";

        dialogue.sentenceStruct[2].leftSide = true;
        dialogue.sentenceStruct[2].name = "Alpha";
        dialogue.sentenceStruct[2].sentence = "Then why are you helping me?";

        dialogue.sentenceStruct[3].leftSide = false;
        dialogue.sentenceStruct[3].name = "Dr. Katherine";
        dialogue.sentenceStruct[3].sentence = "I'll explain in the next level. For now, just focus on getting your body parts back; \n" +
                                                " This level will help you recover your hands";

        dialogue.sentenceStruct[4].leftSide = false;
        dialogue.sentenceStruct[4].name = "Dr. Katherine";
        dialogue.sentenceStruct[4].sentence = "Tip:: You can bounce on enemies to temporarily disable them.\n " +
                                                "Good Luck.";

    }

    static void loadLevel3Dialogue()
    {
        dialogue = new Dialogue();
        dialogue.sentenceStruct = new SentenceStruct[4];

        dialogue.sentenceStruct[0].leftSide = true;
        dialogue.sentenceStruct[0].name = "Alpha";
        dialogue.sentenceStruct[0].sentence = "Why are you helping me, Dr. Katherine?";

        dialogue.sentenceStruct[1].leftSide = false;
        dialogue.sentenceStruct[1].name = "Dr. Katherine";
        dialogue.sentenceStruct[1].sentence = "Alpha, I am your creator. I created you after losing my family in an accident." +
                                                " I couldn't let the government take you away from me.";

        dialogue.sentenceStruct[2].leftSide = false;
        dialogue.sentenceStruct[2].name = "Dr. Katherine";
        dialogue.sentenceStruct[2].sentence = "They wanted to buy you, but I refused. The last 10 years I spent with you has created a bond between us." +
                                                " They have me captive, and I need your help to escape.";

        dialogue.sentenceStruct[3].leftSide = true;
        dialogue.sentenceStruct[3].name = "Alpha";
        dialogue.sentenceStruct[3].sentence = "Hold tight for me, Doctor. I'll save you, No matter the cost.";

    }
    
    static void loadLevel4Dialogue()
    {
        dialogue = new Dialogue();
        dialogue.sentenceStruct = new SentenceStruct[3];

        dialogue.sentenceStruct[0].leftSide = true;
        dialogue.sentenceStruct[0].name = "Alpha";
        dialogue.sentenceStruct[0].sentence = "Delta!!!, It's time to Pay. You won't get away with what you've done.";

        dialogue.sentenceStruct[1].leftSide = false;
        dialogue.sentenceStruct[1].name = "Delta";
        dialogue.sentenceStruct[1].sentence = "You're no match for me, little robot.";

        dialogue.sentenceStruct[2].leftSide = true;
        dialogue.sentenceStruct[2].name = "Alpha";
        dialogue.sentenceStruct[2].sentence = "We'll see about that"; 

    }

    static void epilogueDialogue()
    {
        dialogue = new Dialogue();
        dialogue.sentenceStruct = new SentenceStruct[3];

        dialogue.sentenceStruct[0].leftSide = true;
        dialogue.sentenceStruct[0].name = "Alpha";
        dialogue.sentenceStruct[0].sentence = "(victorious) I did it!";

        dialogue.sentenceStruct[1].leftSide = false;
        dialogue.sentenceStruct[1].name = "Dr. Katherine";
        dialogue.sentenceStruct[1].sentence = "(freed) Alpha, you did it! You saved me!";

        dialogue.sentenceStruct[2].leftSide = true;
        dialogue.sentenceStruct[2].name = "Alpha";
        dialogue.sentenceStruct[2].sentence = "It's all thanks to you, Doc.";
    }
}
