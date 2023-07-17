using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bucket")
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bucket")
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
