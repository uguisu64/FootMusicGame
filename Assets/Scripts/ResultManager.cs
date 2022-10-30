using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultManager : MonoBehaviour
{
    private GameObject dataStore;
    private DataStore ds;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI difficultyText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI perfectText;
    public TextMeshProUGUI goodText;
    public TextMeshProUGUI badText;
    public TextMeshProUGUI missText;
    
    void Start()
    {
        dataStore = GameObject.Find("DataStore");
        ds = dataStore.GetComponent<DataStore>();

        SetMusicData(ds.SelectedMusicData());
        SetResultData(ds.Result);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("MusicSelectScene");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    private void SetMusicData(MusicData musicData)
    {
        titleText.text = musicData.Title;
        difficultyText.text = musicData.Difficulty;
        levelText.text = musicData.Level;
    }

    private void SetResultData(int[] result)
    {
        perfectText.text = "Perfect:" + result[(int)JUDGE_TYPE.perfect].ToString();
        goodText.text = "Good:" + result[(int)JUDGE_TYPE.good].ToString();
        badText.text = "Bad:" + result[(int)JUDGE_TYPE.bad].ToString();
        missText.text = "Miss:" + result[(int)JUDGE_TYPE.miss].ToString();
    }
}
