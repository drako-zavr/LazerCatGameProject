using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    void Update()
    {
        if (transform.position.magnitude > 15.0f)//уничтожение объекта за пределами сцены
        {
            Destroy(gameObject);
        }
    }


    //=============урон противнику=============
    void OnCollisionEnter2D(Collision2D other)
    {
        Enemy1 e = other.collider.GetComponent<Enemy1>(); //столкновение
        Enemy2 r = other.collider.GetComponent<Enemy2>();

        //======Урон по Enemy1======
        if (e != null)
        {
            e.ChangeHealth(-1);
        }
        //======Урон по Enemy2======
        if (r != null)
        {
            r.ChangeHealth(-1);
        }

        Destroy(gameObject);//разрушение пули
    }

}
