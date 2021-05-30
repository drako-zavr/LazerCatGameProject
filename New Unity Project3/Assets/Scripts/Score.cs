using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public static int scoreValue=0;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        //Score.scoreValue = 0;
        score = GetComponent<Text>();
    }

    // ===========ОБНОВЛЕНИЕ СЧЁТА===========
    void Update()
    {
        score.text = "SCORE:" + scoreValue;
    }

    
}
