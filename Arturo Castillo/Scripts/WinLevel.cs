using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {            
            SceneManager.LoadScene("Go to Level 2");
        }
    }

    public void nextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }
}
