using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int coins;
    [SerializeField] TMPro.TextMeshProUGUI coinText;

    public void Increment()
    {
        coins++;
        coinText.text = coins.ToString();
    }
}
