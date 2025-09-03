using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI minutesText, secondsText;

    float timer = 0;

    string Convert(int amount)
    {
        if (amount < 10)
            return $"0{amount}";
        return amount.ToString();
    }

    public void Reset()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        secondsText.text = Convert((int)timer%60);
        minutesText.text = Convert((int)timer/60);
    }
}
