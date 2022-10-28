using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI difficultyText;

    public TextMeshProUGUI perfect;
    public TextMeshProUGUI good;
    public TextMeshProUGUI bad;
    public TextMeshProUGUI miss;

    private void Start()
    {
        UpdateResultText(JUDGE_TYPE.perfect, 0);
        UpdateResultText(JUDGE_TYPE.good, 0);
        UpdateResultText(JUDGE_TYPE.bad, 0);
        UpdateResultText(JUDGE_TYPE.miss, 0);
    }

    public void SetTitleLevelText(string title, string difficulty, string level)
    {
        titleText.text = title;
        difficultyText.text = difficulty + " Lv." + level;
    }

    public void UpdateResultText(JUDGE_TYPE judge, int num)
    {
        switch(judge)
        {
            case JUDGE_TYPE.perfect:
                perfect.text = "Perfect: " + num.ToString();
                break;

            case JUDGE_TYPE.good:
                good.text = "Goog: " + num.ToString();
                break;

            case JUDGE_TYPE.bad:
                bad.text = "Bad: " + num.ToString();
                break;

            case JUDGE_TYPE.miss:
                miss.text = "Miss: " + num.ToString();
                break;

            default:
                break;
        }
    }
}
