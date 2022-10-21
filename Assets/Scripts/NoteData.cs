using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteData : MonoBehaviour
{
    private float timing;
    private float endTiming;
    private int rane;
    private NOTE_TYPE noteType;

    public float Timing
    {
        get { return timing; }
        set { timing = value; }
    }
    public float EndTiming
    {
        get { return endTiming; }
        set { endTiming = value; }
    }
    public NOTE_TYPE NoteType
    {
        get { return noteType; }
        set { noteType = value; }
    }
    public int Rane
    {
        get { return rane; }
        set { rane = value; }
    }

    public void DestroyThisNote()
    {
        Destroy(gameObject);
    }
}
