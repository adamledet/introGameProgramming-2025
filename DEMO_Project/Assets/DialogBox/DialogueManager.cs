using System.Linq;
using JetBrains.Annotations;
using UnityEditor.Search;
using UnityEngine;
using static DialogueNode;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI lineText;
    [SerializeField] OptionUI optionPrefab;
    DialogueNode root, current;
    void Awake()
    {
        var quest = new DialogueNode();
        root = new DialogueNode();
        root.text = "Hello, Stranger!";
        root.options = new()
        {
            new DialogueOption(){text="Good day!", next=quest }
        };
    }

    private void Start()
    {
        Show();
    }

    private void Show()
    {
        lineText.text = current.text;
        foreach (var option in current.options)
        {
            var optionUI = Instantiate(optionPrefab, transform);
            optionUI.Set(this, option);
        }
    }

    internal void Advance(DialogueOption option)
    {
        //var selected = current.options.First(z => z.Equals(option));// Using LinQ
        DialogueOption selected;
        foreach (var item in current.options)// Not using LinQ
        {
            if (item.Equals(option))
            {
                selected = item;
                break;
            }
        }
        //current = selected.next;
        Show();
    }
}