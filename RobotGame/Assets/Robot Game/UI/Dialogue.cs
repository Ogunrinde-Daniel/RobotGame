using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public SentenceStruct[] sentenceStruct;
}

[System.Serializable]
public struct SentenceStruct
{
    public bool leftSide;
    public string name;
    [TextArea(3, 10)]
    public string sentence;
}


