using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    //public Camera cam;
    
    Vector3 mousePos;//позиция курсора

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //считывание позиции курсора
    }
    void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        //поворот в соответствии с позицией курсора
    }
}
