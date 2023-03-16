using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform maincamera;

    // Update is called once per frame
    void Update()
    {
        maincamera.transform.position = new Vector3(0, player.transform.position.y + 2, -13);
    }
}
