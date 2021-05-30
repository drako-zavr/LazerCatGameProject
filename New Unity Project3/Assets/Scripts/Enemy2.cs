using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    //===========ЗДОРОВЬЕ===========
    public int maxHealth = 5;//макс здоровье
    public int health { get { return currentHealth; } }
    int currentHealth; //текущее здоровье

    //===========ДВИЖЕНИЕ===========
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
    float timer;
    int direction = 1;



    Rigidbody2D rigidbody2d;
    Animator animator;

    

    //private bool m_FacingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //===========ИЗМЕНЕНИЕ НАПРАВЛЕНИЯ===========
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {


        //======================ДВИЖЕНИЕ======================
        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;

            // animator.SetFloat("Move X", 0);
            //animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;

             animator.SetFloat("Move X", direction);
            // animator.SetFloat("Move Y", 0);
        }

        rigidbody2d.MovePosition(position);
    }


    //===========НАНЕСЕНИЕ УРОНА===========
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    

    //===========ИЗМЕНЕНИЕ ЗДОРОВЬЯ===========
    public void ChangeHealth(int amount)
    {

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        
        if (currentHealth <= 0)
        {
            //currentHealth = maxHealth;
            //transform.position = new Vector2(-11,2);
            Destroy(gameObject);
            Score.scoreValue += 5;
        }
    }

}
