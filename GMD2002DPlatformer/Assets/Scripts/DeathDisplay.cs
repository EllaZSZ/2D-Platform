// Programmed By Arija

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _deathText;
    int deaths;
    // Start is called before the first frame update
    void Start()
    {
        _deathText.text = "Death Count: " + 0;
    }

    // Update is called once per frame
    public void UpdateDeath()
    {
        _deathText.text = "Death: " + deaths.ToString();
    }

    public void AddDeath()
    {
        deaths++;
        UpdateDeath();
    }
}
