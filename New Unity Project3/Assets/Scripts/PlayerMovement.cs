using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    
    public Rigidbody2D rb;
    public Camera cam;
    

    //===========ДВИЖЕНИЕ===========
    public float moveSpeed = 5f;
    Vector2 movement;
    Vector2 mousePos;



    //===========ЗДОРОВЬЕ===========
    public int maxHealth = 5;//макс здоровье
    public int health { get { return currentHealth; } }
    int currentHealth; //текущее здоровье

    public float timeInvincible = 1.0f; //время неуязвимости после потери здоровья
    bool isInvincible;
    float invincibleTimer;


    //===========ИНТЕРФЕЙС=============
    public HealthBar healthBar;
    public DeathMenu deathMenu;


    //===========АНИМАЦИЯ=============
    public Animator animator;
    private bool m_FacingLeft = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //доступ к Rigidbody2D
        
        //animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        //===========АНИМАЦИЯ===========
        animator.SetFloat("Speed", Mathf.Abs(movement.x));

        if (movement.x > 0 && m_FacingLeft)
        {
            Flip();
        }
        else if (movement.x<0 && !m_FacingLeft)
        {
            Flip();
        }
      
        //считывание позиции курсора
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //таймер временной неуязвимости после урона
        if(isInvincible)
        {
            invincibleTimer -= Time.deltaTime;//Time.deltaTime равен времени прошешему между сменой кадра
            if (invincibleTimer < 0)
                isInvincible = false;
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

       // Vector2  lookDir = mousePos - rb.position;

        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg-90f;
        //rb.rotation = angle;
    }

    //=============ИЗМЕНЕНИЕ ЗДОРОВЬЯ=============
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            //animator.SetTrigger("KittyHit");
            isInvincible = true;
            invincibleTimer = timeInvincible;//запуск таймера неуязвимости
            healthBar.SetHealth(currentHealth); //изменение полоски здоровья
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);//изменение здоровья Mathf.Clamp(новое значение, мин. значение, макс. значение)
        Debug.Log(currentHealth + "/" + maxHealth);//вывод результата в консоль


        //=============КОНЕЦ ИГРЫ=============
        if (currentHealth <= 0)
        {
            
            //Destroy(gameObject);
            //Application.LoadLevel(Application.loadedLevel);
            deathMenu.ShowEndMenu(Score.scoreValue);
            
        }
    }


    //=============ИЗМЕНЕНИЕ НАПРАВЛЕНИЯ=============
    private void Flip()
    {
        m_FacingLeft = !m_FacingLeft;

        Vector3 theScale = transform.localScale;//получаем scale из компонента transform
        theScale.x *= -1;
        transform.localScale = theScale;
        //эта функция разворачивает объект по горизонтали
    }
}
