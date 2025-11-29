using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Vector2 direction;
    private float speed;
    [SerializeField] GameObject playerAttack;
    Rigidbody2D rb;
    bool moving;
    [SerializeField] Renderer background;
    [SerializeField] float bgSlowdown;//hard-set value used to 'slow down' the rate at which the background shifts.
    private SpriteRenderer myImage;

    [SerializeField] Image attackUI;
    [SerializeField] Image dashUI;

    private Vector2 dashLocation;
    private float dashTimer;
    private float dashSpeed;
    private float dashMaxDuration;

    private float attackCD;
    private float attackCDLeft;
    private float dashCD;
    private float dashCDLeft;

    PlayerStats myStats;

    private void Start()
    {
        moving = false;
        myStats = this.GetComponent<PlayerStats>();

        speed = myStats.speed;
        dashSpeed = speed*2;
        dashMaxDuration = myStats.dashMaxDuration;
        attackCD = myStats.attackCD;
        dashCD = myStats.dashCD;

        rb = GetComponent<Rigidbody2D>();
        myImage = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dashTimer > 0)
        {
            ApplyMovement(dashLocation * dashSpeed * (dashTimer/dashMaxDuration) * Time.deltaTime);
            dashTimer -= Time.deltaTime;
        }
        else { dashTimer = 0; }

        if (moving && dashTimer<=0)//Check if player is moving using their own movement
        {
            ApplyMovement(direction * speed * Time.deltaTime);
        }

        // Tick down attack and dash cooldowns
        if (attackCDLeft > 0) { attackCDLeft -= Time.deltaTime; attackUI.fillAmount = (attackCDLeft / attackCD); } else {  attackCDLeft = 0; attackUI.fillAmount = 0; }
        if (dashCDLeft > 0) {  dashCDLeft -= Time.deltaTime; dashUI.fillAmount = (dashCDLeft / dashCD); } else { dashCDLeft = 0; dashUI.fillAmount = 0; }
    }

    // Movement when the player uses input
    public void MovePlayer(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        if(dir.magnitude > 0) { moving = true; }
        else { moving = false; }
        direction = new Vector3(dir.x, dir.y, 0).normalized;
        //Debug.Log($"MOVING: {direction}");
        if(Math.Abs(direction.x) > 0 && Time.timeScale>0)
        {
            if (direction.x < 0)
            {
                myImage.flipX = true;
            }
            else
            {
                myImage.flipX = false;
            }
        }
        //rb.AddForce(direction);
    }

    //Apply player Movement
    public void ApplyMovement(Vector3 dir)
    {
        rb.MovePosition(transform.position += dir);
        if (bgSlowdown != 0) { background.material.mainTextureOffset += (new Vector2(dir.x, dir.y)) / bgSlowdown; }// Should multiply this by player speed to account for variable speeds
    }

    public void PlayerAttack(InputAction.CallbackContext context)
    {
        if(context.performed && attackCDLeft<=0)
        {
            var bullet = Instantiate(playerAttack, transform.position, Quaternion.identity);
            Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x, (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())).y);
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 dirVector = (mousePos - myPos);
            bullet.GetComponent<PlayerAttack>().direction = dirVector.normalized;
            bullet.GetComponent<PlayerAttack>().damage = myStats.damage;
            bullet.GetComponent<PlayerAttack>().health = myStats.bulletHealth;
            attackCDLeft = attackCD;
        }
    }

    public void PlayerSecondary(InputAction.CallbackContext context)
    {
        if (context.performed && dashCDLeft <= 0)
        {
            dashTimer = dashMaxDuration;
            Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x, (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())).y);
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            dashLocation = (mousePos - myPos).normalized;
            dashCDLeft = dashCD;
            //Debug.Log($"{dashLocation} - {(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position).normalized}");
        }
    }

    public void UpdateSpeed(float newSpd, float newAttackCD)
    {
        speed = newSpd;
        attackCD = newAttackCD;
        dashSpeed = speed * 2;
    }
}
