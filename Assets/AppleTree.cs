using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;
    public GameObject poisonApplePrefab;
    public float poisonChance = 0.1f; 

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DropApple),2f);
    }

    void DropApple()
{
    GameObject apple;

    if (Random.value < poisonChance)
    {
        apple = Instantiate<GameObject>(poisonApplePrefab);
    }
    else
    {
        apple = Instantiate<GameObject>(applePrefab);
    }

    apple.transform.position = transform.position;
    Invoke(nameof(DropApple), appleDropDelay);
}

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed* Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
           speed = Mathf.Abs(speed); 
        }else if (pos.x >leftAndRightEdge)
        {
           speed = -Mathf.Abs(speed); 
        }
        // else if(Random.value < changeDirChance)
        // {
        //     speed *= -1;
        // }
    }
    void FixedUpdate()
    {
        if(Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}
