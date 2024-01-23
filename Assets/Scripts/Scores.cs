using UnityEngine;
using UnityEngine.UI;
using YG;

public class Scores : MonoBehaviour
{
    [SerializeField] Text _scoresText;
    [SerializeField] Text _recordText;
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
            YandexGame.NewLeaderboardScores("Scores", _scores);
            _recordText.text = $"NEW BEST SCORE!!!";
            if (YandexGame.SDKEnabled)
            {
                if (YandexGame.EnvironmentData.language == "ru")
                {
                    _recordText.text = $"ÍÎÂÛÉ ÐÅÊÎÐÄ!!!";
                }
                if (YandexGame.EnvironmentData.language == "tr")
                {
                    _recordText.text = $"Yeni Rekor!!!";
                }
            }
            ProjectContext.Instance.Settings.SetTopScore(_scores);
        } else
        {
            _recordText.text = $"Best score: {_topScore}";
            if (YandexGame.SDKEnabled)
            {
                if (YandexGame.EnvironmentData.language == "ru")
                {
                    _recordText.text = $"Ëó÷øèé ðåçóëüòàò: {_topScore}";
                }
                if (YandexGame.EnvironmentData.language == "tr")
                {
                    _recordText.text = $"en iyi puan: {_topScore}";
                }
            }
        }
    }
}
