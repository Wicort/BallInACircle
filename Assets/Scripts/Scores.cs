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
        _scoresText.text = _scores.ToString();
    }

    private void OnEnable()
    {
        Point.onCollision += AddScore;
    }

    private void OnDisable()
    {
        Point.onCollision -= AddScore;
    }

    private void AddScore()
    {
        _scores += 1;
        _scoresText.text = _scores.ToString();
    }
}
