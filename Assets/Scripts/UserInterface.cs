using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private float playerHeight;
    private float playerHighest;
    [SerializeField] TextMeshProUGUI heightNumTMP;
    [SerializeField] TextMeshProUGUI highestNumTMP;

    void Update()
    {
        playerHeight = player.transform.position.y;
        heightNumTMP.text = Mathf.Round(playerHeight).ToString();

        if (playerHeight >= playerHighest)
        {
            playerHighest = playerHeight;
            highestNumTMP.text = Mathf.Round(playerHighest).ToString();
        }

    }
}
