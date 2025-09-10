using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest_Data
{
    public string title;
    private List<QuestReq> reqs = new();

    public Quest_Data(string title)
    {
        this.title = title;
    }

    public void Add(QuestReq req) => reqs.Add(req);
    public QuestReq Get(int index) => reqs[index];
    public List<QuestReq> GetAll() => reqs.ToList();
}
