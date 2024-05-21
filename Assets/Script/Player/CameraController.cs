using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    private Vector3 Camerapos;
    // Start is called before the first frame update
    void Start()
    {
        Camerapos = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = Player.transform.position + Camerapos;
    }
}
