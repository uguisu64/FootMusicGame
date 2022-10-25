using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGameManager : MonoBehaviour
{
    public static bool isObject = false;

    private TextMeshProUGUI titleText;
    private TextMeshProUGUI levelText;

    private int index;
    private bool isSelectScene;
    private bool keyInputFlg;
    // Start is called before the first frame update
    void Start()
    {
        if (isObject)
        {
            isObject = true;
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        index = 0;
        isSelectScene = true;
        keyInputFlg = true;
        FindSelectMusicSceneObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelectScene)
        {
            if(Input.GetKeyDown(KeyCode.S) && keyInputFlg)
            {
                keyInputFlg = false;
                StartCoroutine(KeyFlg());
            }
            if(Input.GetKeyDown(KeyCode.L) && keyInputFlg)
            {
                keyInputFlg = false;
                StartCoroutine(KeyFlg());
            }
        }
    }

    private void FindSelectMusicSceneObject()
    {
        titleText = GameObject.Find("TitleText").GetComponent<TextMeshProUGUI>();
        levelText = GameObject.Find("LevelText").GetComponent<TextMeshProUGUI>();
    }

    private IEnumerator KeyFlg()
    {
        yield return new WaitForSeconds(0.04f);

        keyInputFlg = true;
    }
}
