using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject uiOject;

    void Start()
    {
        uiOject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.tag=="Player")
        {
            uiOject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1);
        Destroy(uiOject);
        Destroy(gameObject);
    }
}
