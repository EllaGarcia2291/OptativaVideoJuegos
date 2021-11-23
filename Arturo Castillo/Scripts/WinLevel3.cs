using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel3 : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Go to Level 4");
        }
    }

    public void nextLevel()
    {
        SceneManager.LoadScene("Level 4");
    }
}
