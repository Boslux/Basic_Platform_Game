using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public bool next = false;
    private void Update()
    {
        NextLevel();
    }
    void NextLevel()
    {
        if (next==true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D cls)
    {
        if (cls.gameObject.CompareTag("Player"))
        {
            next = true;
        }
    }
}
