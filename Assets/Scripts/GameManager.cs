using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject notes;
    private float time;
    private NotesScript ns;
    private AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        ns = notes.GetComponent<NotesScript>();
        music = GetComponent<AudioSource>();
        time = -2.0f;
        StartCoroutine(StartMusic());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        JUDGE_TYPE back = JUDGE_TYPE.none;
        ns.MissCheck(time);
        if (Input.GetKeyDown(KeyCode.S))
        {
            back = ns.PressRane(0, time);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            back = ns.PressRane(1, time);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            back = ns.PressRane(2, time);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            back = ns.PressRane(3, time);
        }
    }

    public IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(2.0f);

        music.Play();
    }
}
