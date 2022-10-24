using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject notes;
    public GameObject uiManager;
    private int[] result = { 0, 0, 0, 0 };
    private float time;
    private NotesScript ns;
    private UIManager uim;
    private AudioSource music;
    private bool[] keyUpFlgs = { false, false, false, false };
    private bool[] keyInputFlgs = { false, false, false, false };
    // Start is called before the first frame update
    void Start()
    {
        ns = notes.GetComponent<NotesScript>();
        uim = uiManager.GetComponent<UIManager>();
        music = GetComponent<AudioSource>();
        time = -2.0f;
        StartCoroutine(StartMusic());
    }

    // Update is called once per frame
    void Update()
    {
        //現在時刻
        time += Time.deltaTime;
        //毎フレームミスチェック
        ns.MissCheck(time);
        //通常ノーツ処理用
        if (Input.GetKeyDown(KeyCode.S))
        {
            AddResult(ns.PressRane(0, time));
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            AddResult(ns.PressRane(1, time));
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            AddResult(ns.PressRane(2, time));
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            AddResult(ns.PressRane(3, time));
        }

        //HoldNote用の入力管理
        HoldKeyCheck();
        for (int i = 0; i < 4; i++)
        {
            AddResult(ns.HoldCheckRane(i, time, keyInputFlgs[i]));
        }
    }

    public void AddResult(JUDGE_TYPE judge)
    {
        if (judge == JUDGE_TYPE.none) return;

        result[(int)judge] += 1;
        uim.UpdateResultText(judge, result[(int)judge]);
    }

    public IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(2.0f);

        music.Play();
    }

    private void HoldKeyCheck()
    {
        if (Input.GetKey(KeyCode.S))
        {
            keyInputFlgs[0] = true;
            keyUpFlgs[0] = false;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            keyUpFlgs[0] = true;
        }
        else
        {
            if (keyUpFlgs[0])
            {
                keyInputFlgs[0] = false;
                keyUpFlgs[0] = false;
            }
        }
        if (Input.GetKey(KeyCode.F))
        {
            keyInputFlgs[1] = true;
            keyUpFlgs[1] = false;
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            keyUpFlgs[1] = true;
        }
        else
        {
            if (keyUpFlgs[1])
            {
                keyInputFlgs[1] = false;
                keyUpFlgs[1] = false;
            }
        }
        if (Input.GetKey(KeyCode.J))
        {
            keyInputFlgs[2] = true;
            keyUpFlgs[2] = false;
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            keyUpFlgs[2] = true;
        }
        else
        {
            if (keyUpFlgs[2])
            {
                keyInputFlgs[2] = false;
                keyUpFlgs[2] = false;
            }
        }
        if (Input.GetKey(KeyCode.L))
        {
            keyInputFlgs[3] = true;
            keyUpFlgs[3] = false;
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            keyUpFlgs[3] = true;
        }
        else
        {
            if (keyUpFlgs[3])
            {
                keyInputFlgs[3] = false;
                keyUpFlgs[3] = false;
            }
        }
    }
}
