using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;


    public float timeRespawn = 5.0f;

    public float speed;
    public float changeTime = 3.0f;
    float walktimer;
    public bool vertical;
    int direction = 1;
    //int directionY = 1;

    float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        //if (spawnTimer < 0)
            //RespawnEnemy();

        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 4)
        {
            RespawnEnemy();
        }

        //if (walktimer < 0)
        //{
        //    if (direction==1)
        //        direction = 3;
        //    if (direction == 3)
        //        direction = -1;
        //    if (direction == -1)
        //        direction = -3;
        //    if (direction == -3)
        //        direction = 1;
        //    walktimer = changeTime;
        //    vertical = !vertical;
        //}
    }
    void FixedUpdate()
    {



        Vector2 position = transform.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * (direction%2);

            // animator.SetFloat("Move X", 0);
            //animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * (direction % 2);

            //animator.SetFloat("Move X", direction);
            // animator.SetFloat("Move Y", 0);
        }

        //transform.MovePosition(position);
        transform.position = position;
    }
    void RespawnEnemy()
    {
        //GameObject Enemy = Instantiate(enemy1Prefab, transform.position, transform.rotation);

        GameObject a = Instantiate(enemy1Prefab) as GameObject;
        //Enemy1 e = other.collider.GetComponent<Enemy1>();
        
        spawnTimer = timeRespawn;
        
    }


}
