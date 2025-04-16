using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera Camera;
    public Transform CameraTarget;
    public Vector3 offset;
    public float lerpSpeed = .1f;
    // Start is called before the first frame update
    void Start()
    {
        Camera = gameObject.GetComponent<Camera>();
        offset = gameObject.transform.position - CameraTarget.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, CameraTarget.position + offset, lerpSpeed);
        
        
    }
}