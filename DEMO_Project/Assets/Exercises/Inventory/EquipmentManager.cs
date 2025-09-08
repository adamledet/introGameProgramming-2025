using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] GameObject headEquip;
    [SerializeField] GameObject chestEquip;
    [SerializeField] GameObject handEquip;
    [SerializeField] GameObject backEquip;


    public void EquipItem(GameObject item, string location)
    {
        item.SetActive(true);
        if (location.ToLower() == "head")
        {
            if(headEquip.activeSelf){ headEquip.SetActive(false); }
            headEquip = item;
        }
        if (location.ToLower() == "chest")
        {
            if(chestEquip.activeSelf){ chestEquip.SetActive(false); }
            chestEquip = item;
        }
        if (location.ToLower() == "hand")
        {
            if (handEquip.activeSelf) { handEquip.SetActive(false); }
            handEquip = item;
        }
        if (location.ToLower() == "back")
        {
            if(backEquip.activeSelf){ backEquip.SetActive(false); }
            backEquip = item;
        }
    }
}
