using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scores : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoresText;
    [SerializeField] TextMeshProUGUI _recordText;
    private int _scores = 0;

    private int _topScore => ProjectContext.Instance.Settings.CurrentSettings.TopScore;

    private void Start()
    {
        initialize();
    }

    private void OnEnable()
    {
        Point.onCollision += AddScore;
        Game.onStartGame += initialize;
        Game.onLooseGame += showTopScore;
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
        _recordText.gameObject.SetActive(false);
    }

    private void showTopScore()
    {
        _recordText.gameObject.SetActive(true);
        if (_topScore < _scores)
        {
            _recordText.text = $"NEW BEST SCORE!!!";
            ProjectContext.Instance.Settings.SetTopScore(_scores);
        } else
        {
            _recordText.text = $"Best score: {_topScore}";
        }
    }
}
