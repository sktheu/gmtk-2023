using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Configurações:")] 
    [SerializeField] private TextMeshProUGUI txtMP;

    public static ScoreManager Instance;

    private int _currentScore = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore()
    {
        _currentScore++;
        txtMP.text = _currentScore.ToString();
    }
}
