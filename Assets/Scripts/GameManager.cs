using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int playerHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
    }
}
