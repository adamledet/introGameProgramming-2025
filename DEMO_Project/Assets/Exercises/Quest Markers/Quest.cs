using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest
{
    public string title;
    private List<QuestReq> reqs = new();

    public Quest(string title)
    {
        this.title = title;
    }

    public void Add(QuestReq req) => reqs.Add(req);
    public QuestReq Get(int index) => reqs[index];
    public List<QuestReq> GetAll() => reqs.ToList();
}
