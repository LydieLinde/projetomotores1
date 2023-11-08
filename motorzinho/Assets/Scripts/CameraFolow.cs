using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    private Transform alvo;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindWithTag("Player").transform;
        offset = alvo.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = alvo.position - offset;
    }
}