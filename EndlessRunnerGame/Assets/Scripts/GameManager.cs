using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager Instance;

    [SerializeField] Text ScoreText;

    [SerializeField] PlayerMovements playerMovements;

    public void IncrementScore()
    {
        score++;
        ScoreText.text = "Score: " + score;

        //Increase the player's Speed
        playerMovements.speed += playerMovements.speedIncreasePerPoint;
    }

	private void Awake()
	{
		Instance = this;
	}

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
