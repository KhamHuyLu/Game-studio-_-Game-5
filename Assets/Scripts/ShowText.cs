using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    [SerializeField] private GameObject textObject;

    private void Start()
    {
        textObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        textObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textObject.SetActive(false);
    }
}
