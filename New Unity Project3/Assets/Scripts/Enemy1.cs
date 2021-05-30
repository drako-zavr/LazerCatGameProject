using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using System;
//using System.Linq;
//using System.Text.RegularExpressions;

public class Enemy1 : MonoBehaviour
{


    //===========ЗДОРОВЬЕ===========
    public int maxHealth = 5;//макс здоровье
    public int health { get { return currentHealth; } }
    int currentHealth; //текущее здоровье


    private bool m_FacingLeft = true;
    //Vector3 prevLoc= Vector3.zero;
    private bool spawnPos = true;

    //КОМПОНЕНТЫ
    public Animator animator;
    Rigidbody2D rigidbody2d;
   
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rigidbody2d = GetComponent<Rigidbody2D>();
        //timer = changeTime;
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector2 position = rigidbody2d.position;
        if (position.x > 0 && m_FacingLeft)
        {

            Flip();
        }
        else if (position.x < 0 && !m_FacingLeft)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {

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
       
       if(currentHealth<=0)
        {
            //var rand = new System.Random();
            //var bytes = new byte[1];
            //rand.NextBytes(bytes);



            //transform.position = new Vector2(0, 8);
            if (spawnPos)
            { transform.position = new Vector2(-11, -7); }
            else  
            { transform.position = new Vector2(11, 7); }
            //if (bytes[1] % 4 == 0)
            //{ transform.position = new Vector2(-11, -7); }
            //else if (bytes[1] % 4 == 1)
            //{ transform.position = new Vector2(11, 7); }
            //else if (bytes[1] % 4 == 3)
            //{ transform.position = new Vector2(-11, 7); }
            //else
            //{ transform.position = new Vector2(11, -7); }

            // Destroy(gameObject);
            Score.scoreValue += 10;
            currentHealth = maxHealth;
            spawnPos = !spawnPos;
        }    
    }

    //=============ИЗМЕНЕНИЕ НАПРАВЛЕНИЯ=============
    private void Flip()
    {

        m_FacingLeft = !m_FacingLeft;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
