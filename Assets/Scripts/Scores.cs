using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scores : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoresText;
    private int _scores = 0;

    private void Start()
    {
        initialize();
    }

    private void OnEnable()
    {
        Point.onCollision += AddScore;
        Game.onStartGame += initialize;
    }

    private void OnDisable()
    {
        Point.onCollision -= AddScore;
        Game.onStartGame -= initialize;
    }

    private void AddScore()
    {
        _scores += 1;
        _scoresText.text = _scores.ToString();
    }

    private void initialize()
    {
        _scores = 0;
        _scoresText.text = _scores.ToString();
    }
}
