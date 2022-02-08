using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text Text;
    public Player player;

    void Update()
    {
        Text.text = "Your score: " + player.Score.ToString();
    }
}
