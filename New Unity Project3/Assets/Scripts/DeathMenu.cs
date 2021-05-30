using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        //при запуске меню не отображается
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //===========ОТОБРАЖЕНИЕ МЕНЮ===========
    public void ShowEndMenu(float score)
    {
        gameObject.SetActive(true);
    }

    // ===========ПЕРЕЗАПУСК ИГРЫ===========
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Score.scoreValue = 0;
    }
}
