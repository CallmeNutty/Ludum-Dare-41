using UnityEngine;
using System.Collections;

public class CameraScreenResolution : MonoBehaviour
{
    public bool maintainWidth = true;
    [Range(-1, 1)]
    public int adaptPosition;
    
    float defaultWidth;
    float defaultHeight;
    
    Vector3 CameraPos;

    // Use this for initialization
    void Start()
    {
        CameraPos = Camera.main.transform.position;

        defaultHeight = Camera.main.orthographicSize;
        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
    }
}