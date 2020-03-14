using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreEssences : MonoBehaviour {

    public static int _goldStarScore = 0, _greenStarScore = 0, _redStarScore = 0, _purpelStarScore = 0, _lifeScore = 3;
    public Text GoldStarScoreText;
    public Text GreenStarScoreText;
    public Text RedStarScoreText;
    public Text PurpelStarScoreText;
    public Text LifeScoreText;


    public int GetLifeScore()
    {
        return _lifeScore;
    }

    void Start()
    {
        UpdateScoreText(ScoreType.All);
    }

    public enum ScoreType
    {
        //Crea Tags con estos mismos nombres y asignalos a los prefab con estos mismos nombres.

        GoldStar,
        GreenStar,
        RedStar,
        PurpelStar,
        Rock,
        All

    }

    public void UpdateScore(ScoreType scoreType, int value = 1)
    {
        switch (scoreType)
        {
            case ScoreType.GoldStar:
                _goldStarScore += value;
                UpdateScoreText(ScoreType.GoldStar);
                break;

            case ScoreType.GreenStar:
                _greenStarScore += value;
                UpdateScoreText(ScoreType.GreenStar);
                break;

            case ScoreType.RedStar:
                _redStarScore += value;
                UpdateScoreText(ScoreType.RedStar);
                break;

            case ScoreType.PurpelStar:
                _purpelStarScore += value;
                UpdateScoreText(ScoreType.PurpelStar);
                break;
            case ScoreType.Rock:
                _lifeScore += value;
                UpdateScoreText(ScoreType.Rock);
                break;

        }
    }


    public void UpdateScoreText(ScoreType scoreType)
    {
        if (scoreType == ScoreType.All || scoreType == ScoreType.GoldStar)
		    GoldStarScoreText.text = _goldStarScore.ToString();
        if (scoreType == ScoreType.All || scoreType == ScoreType.GreenStar)
		    GreenStarScoreText.text = _greenStarScore.ToString();
        if (scoreType == ScoreType.All || scoreType == ScoreType.RedStar)
		    RedStarScoreText.text = _redStarScore.ToString();
        if (scoreType == ScoreType.All || scoreType == ScoreType.PurpelStar)
            PurpelStarScoreText.text = _purpelStarScore.ToString();
        if (scoreType == ScoreType.All || scoreType == ScoreType.Rock)
            LifeScoreText.text = _lifeScore.ToString();

    }


}
