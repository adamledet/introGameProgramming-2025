using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float maxHp;
    float health;
    [SerializeField] public float speed;
    [SerializeField] float damage;
    [SerializeField] float exp;
    float xpToLevelUp;
    int level;
    [SerializeField] TextMeshProUGUI levelDisplay;
    PlayerMovement myMovement;
    [SerializeField] Image healthBar;
    [SerializeField] Image xpBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        level = 1;
        exp = 0;
        xpToLevelUp = 100;
        health = maxHp;
        healthBar.fillAmount = (health / maxHp);
        xpBar.fillAmount = exp / xpToLevelUp;

        myMovement = this.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        GainXP(10 * Time.deltaTime);//Test gaining 10xp/second
        TakeDamage(5 * Time.deltaTime);//Test taking 5 dmg/second
    }

    public void GainXP(float xp)
    {
        exp += xp;
        xpBar.fillAmount = exp / xpToLevelUp;
        if (exp >= xpToLevelUp) { LevelUp(); }
    }

    private void LevelUp()
    {
        exp = 0;
        xpToLevelUp *= 1.1f;
        maxHp += maxHp / 10;
        speed += speed / 10;
        myMovement.UpdateSpeed(speed);
        damage += damage / 10;
        health = maxHp;//Full Heal on levelup
        level += 1;
        levelDisplay.text = level.ToString();
        xpBar.fillAmount = exp / xpToLevelUp;
        healthBar.fillAmount = (health / maxHp);
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        healthBar.fillAmount = (health / maxHp);
        //If health less than 0, make gameover
    }
}
