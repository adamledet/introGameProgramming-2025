using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    List<Quest> quests = new List<Quest>();
    [SerializeField] GameObject questPrefab, reqPrefab;
    [SerializeField] Transform parent;
    private void Awake()
    {
        var quest1 = new Quest("Traveling");
        quest1.Add(new QuestReq("Go to Marker 1"));
        quests.Add(quest1);
    }

    private void ShowQuest(Quest quest)
    {
        var questObj = Instantiate(questPrefab, parent);
        foreach (var req in quest.GetAll())
        {
            //var reqObj = Instantiate(reqPrefab);
        }
    }
}
