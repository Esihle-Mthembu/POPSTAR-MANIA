using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public List<DialogueLine> lines;

    public static implicit operator DialogueData(DialogueLine v)
    {
       throw new NotImplementedException();
    }
}