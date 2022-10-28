using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectSceneManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI difficultyText;
    public TextMeshProUGUI levelText;

    private bool keyInputFlg;

    private GameObject dataStore;
    private DataStore ds;

    void Start()
    {
        keyInputFlg = true;

        dataStore = GameObject.Find("DataStore");
        ds = dataStore.GetComponent<DataStore>();
        SetMusicData(ds.ChangeIndexReturnMusicData(0));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && keyInputFlg)
        {
            keyInputFlg = false;
            StartCoroutine(KeyFlg());
            SetMusicData(ds.ChangeIndexReturnMusicData(-1));
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene("MainScene");
        }
        if (Input.GetKeyDown(KeyCode.L) && keyInputFlg)
        {
            keyInputFlg = false;
            StartCoroutine(KeyFlg());
            SetMusicData(ds.ChangeIndexReturnMusicData(1));
        }
    }

    //É`ÉÉÉ^ÉäÉìÉOëŒçÙ
    private IEnumerator KeyFlg()
    {
        yield return new WaitForSeconds(0.04f);

        keyInputFlg = true;
    }

    private void SetMusicData(MusicData musicData)
    {
        titleText.text = musicData.Title;
        difficultyText.text = musicData.Difficulty;
        levelText.text = "Level:" + musicData.Level;
    }
}
