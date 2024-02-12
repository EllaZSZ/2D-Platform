// Programmed By Arija

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
    }

    // Update is called once per frame
    public void UpdateScore(int scoreInc)
    {
        _scoreText.text = "Score: " + scoreInc.ToString();
    }
}
