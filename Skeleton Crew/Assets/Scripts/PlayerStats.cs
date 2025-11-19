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


    [SerializeField] TextMeshProUGUI levelDisplay;
    PlayerMovement myMovement;
    [SerializeField] Image healthBar;
    [SerializeField] Image xpBar;
    [SerializeField] float iFrames;//User set invincibility frames on-hit
    private float iTime;//Remaining invincibility time
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] SpriteRenderer myImage;

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
}
