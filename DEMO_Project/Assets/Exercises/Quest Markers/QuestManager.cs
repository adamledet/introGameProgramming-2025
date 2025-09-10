using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    List<Quest_Data> quests = new List<Quest_Data>();
    [SerializeField] QuestComponent questPrefab;
    [SerializeField] GameObject reqPrefab;
    [SerializeField] Transform parent;
    private void Awake()
    {
        var quest1 = new Quest_Data("Traveling");
        quest1.Add(new QuestReq("Go to Marker 1"));
        quests.Add(quest1);
    }

    private void Start()
    {
        ShowQuest(quests[0]);
    }

    private void ShowQuest(Quest_Data quest)
    {
        QuestComponent questObj = Instantiate(questPrefab, parent);
        //questObj.Populate(quest);
        /*foreach (var req in quest.GetAll())
        {
            //var reqParent = questObj.GetComponentInChildren<QuestRequirement>().transform;
            //var reqParent = questObj.transform.GetChild(1);
            //var reqObj = Instantiate(reqPrefab, reqParent);
        }*/
    }
}
