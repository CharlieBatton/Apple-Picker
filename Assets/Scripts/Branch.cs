using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Branch : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Basket"))
        {
            Debug.Log("Branch hit the basket! Game Over.");
            SceneManager.LoadScene("GameOverScreen");
        }
    }
}
