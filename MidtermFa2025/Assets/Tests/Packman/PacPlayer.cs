using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PacPlayer : MonoBehaviour
{
    public float powertimer;
    [SerializeField] float powerMax;
    [SerializeField] Image powerMeter;
    public GameObject defeatScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powertimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        powertimer -= Time.deltaTime;
        Debug.Log(powertimer);
        if (powertimer > 0)
        {
            powerMeter.fillAmount = (powertimer / powerMax);
        }
        else
        {
            powerMeter.fillAmount = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        var power = other.gameObject.GetComponent<Powerup>();
        if (power != null)
        {
            powertimer = powerMax;
            Destroy(other.gameObject);
        }
    }
}
