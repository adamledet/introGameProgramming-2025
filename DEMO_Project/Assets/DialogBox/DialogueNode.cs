using System.Collections.Generic;
using UnityEngine;

public class DialogueNode : MonoBehaviour
{
    public string text;
    public List<DialogueOption> options = new();

    public class DialogueOption
    {
        public string text;
        public DialogueNode next;
    }
}
