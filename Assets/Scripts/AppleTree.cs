using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;
    public GameObject poisonApplePrefab;
    public float poisonChance = 0.2f; 
    public GameObject branchPrefab;
    public float branchChance = 0.1f;


    [Header("Round System")]
    public int round = 1;
    public int pointsPerRound = 1000;
    public Text roundText;
    public ScoreCounter scoreCounter;
    public float speedIncreasePerRound = 0.5f;
    public float dropDelayDecreasePerRound = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DropApple),2f);
        UpdateRoundText();
    }

    void DropApple()
{
    GameObject apple;

    float rand = Random.value;

    if (rand < branchChance)
    {
        apple = Instantiate<GameObject>(branchPrefab);
    }
    else if (rand < branchChance + poisonChance)
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

        CheckRound();
    }
    void FixedUpdate()
    {
        if(Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }

    void CheckRound()
    {
        if(scoreCounter.score >= round * pointsPerRound && round < 4)
        {
            round++;
            // Increase speed slightly
            speed = speed * speedIncreasePerRound;
            // Drop apples slightly faster
            appleDropDelay = Mathf.Max(0.1f, appleDropDelay - dropDelayDecreasePerRound);
            UpdateRoundText();
        }
    }

    void UpdateRoundText()
    {
        if(roundText != null)
        {
            roundText.text = "Round: " + round;
        }
    }
}
