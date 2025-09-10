using UnityEngine;
using static DialogueNode;

public class OptionUI : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI titleText;
    [SerializeField] DialogueOption option;
    [SerializeField] DialogueManager manager;
    internal void Set(DialogueManager manager, DialogueNode.DialogueOption option)
    {
        this.manager = manager;
        titleText.text = option.text;
    }

    public void Choose()
    {
        manager.Advance(option);
    }
}
