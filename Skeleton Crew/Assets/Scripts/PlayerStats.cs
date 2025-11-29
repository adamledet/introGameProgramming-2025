using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float maxHp;
    float health;
    [SerializeField] public float speed;
    float dashSpeed;
    [SerializeField] public float dashMaxDuration;
    [SerializeField] public float damage;
    [SerializeField] float exp;
    float xpToLevelUp;
    int level;
    [SerializeField] public float attackCD;
    [SerializeField] public float dashCD;
    [SerializeField] public int bulletHealth;
    private float timeValue;


    [SerializeField] TextMeshProUGUI levelDisplay;
    PlayerMovement myMovement;
    [SerializeField] Image healthBar;
    [SerializeField] Image xpBar;
    [SerializeField] float iFrames;//User set invincibility frames on-hit
    private float iTime;//Remaining invincibility time
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] SpriteRenderer myImage;

    [SerializeField] GameObject LevelUpScreen;
    [SerializeField] TextMeshProUGUI LevelUpScreenText;
    [SerializeField] GameObject LevelUpChoice_1;
    [SerializeField] GameObject LevelUpChoice_2;
    [SerializeField] GameObject LevelUpChoice_3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        level = 1;
        exp = 0;
        xpToLevelUp = 100;
        health = maxHp;
        healthBar.fillAmount = (health / maxHp);
        xpBar.fillAmount = exp / xpToLevelUp;
        dashSpeed = speed * 2;
        if (bulletHealth <= 0) { bulletHealth = 1; }

        LevelUpScreen.SetActive(false);
        myMovement = this.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //GainXP(10 * Time.deltaTime);//Test gaining 10xp/second
        //TakeDamage(5 * Time.deltaTime);//Test taking 5 dmg/second
        if (iTime > 0)
        {
            myImage.color = Color.red;
            iTime -= Time.deltaTime;
        }
        else
        {
            myImage.color = Color.white;
            iTime = 0;
        }
        //Debug.Log(iTime);
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
        //maxHp += maxHp / 10;
        //speed += speed / 10;
        //myMovement.UpdateSpeed(speed);
        //damage += damage / 10;
        //health = maxHp;//Full Heal on levelup
        level += 1;
        levelDisplay.text = level.ToString();
        xpBar.fillAmount = exp / xpToLevelUp;
        timeValue = Time.timeScale;
        Time.timeScale = 0;
        LevelUpScreen.SetActive(true);
        LevelUpScreenText.text = $"{level-1} --> {level}\r\nLEVEL UP!\r\nChoose your bonus:";
    }

    public void TakeDamage(float dmg)
    {
        if(iTime <=0)
        {
            health -= dmg;
            healthBar.fillAmount = (health / maxHp);
            iTime = iFrames;
            if(health <=0)
            {
                gameOverScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void CloseLevelUp()
    {
        LevelUpScreen.SetActive(false);
        Time.timeScale = timeValue;
    }

    public void LevelUp_FullHeal()
    {
        maxHp += maxHp / 10;
        health = maxHp;
        healthBar.fillAmount = (health / maxHp);
        CloseLevelUp();
    }
    public void LevelUp_ProjectilePierce()
    {
        damage += damage / 10;
        bulletHealth += 1;
        CloseLevelUp();
    }
    public void LevelUp_Swift()
    {
        speed += speed / 10;
        attackCD = (attackCD * 0.9f);
        myMovement.UpdateSpeed(speed, attackCD);
        CloseLevelUp();
    }
}
