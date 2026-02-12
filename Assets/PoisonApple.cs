using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonApple : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Basket"))
        {
            Destroy(gameObject);
            ApplePicker ap = Camera.main.GetComponent<ApplePicker>();
            ap.AppleMissed();
        }
    }
}
