using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesScript : MonoBehaviour
{
    public float speed;

    public GameObject nomalNote;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }
}
