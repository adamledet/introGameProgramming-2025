using UnityEngine;
using UnityEngine.UI;

public class HealthDecay : MonoBehaviour
{
    [SerializeField] Image bar;// Health Bar
    [SerializeField] int decay;
    [SerializeField] int maxHealth;
    [SerializeField] float currentHealth;
    float counter = 0;
    [SerializeField] int decayTime;
    [SerializeField] float healing;

    // Update is called once per frame
    void Update()
    {
        // Health decreases based on framerate (slowly over time)
        currentHealth -= decay*Time.deltaTime;
        bar.fillAmount = currentHealth / maxHealth;

        // Health decreases in set 'ticks'
        /*if (counter >= decayTime)
        {
            counter = 0;
            currentHealth -= decay;
            bar.fillAmount = currentHealth / maxHealth;
        }
        else
        {
            counter += Time.deltaTime;
        }*/
    }

    internal void Increment()
    {
        currentHealth += healing;
        if (currentHealth > maxHealth) { currentHealth = maxHealth; }
        bar.fillAmount = currentHealth / maxHealth;
    }
}
