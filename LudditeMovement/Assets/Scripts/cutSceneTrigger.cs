using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutSceneTrigger : MonoBehaviour
{
    public bool playerOnSite;
    public GameObject cutSceneToActive;


    void Start()
    {
        playerOnSite = false;
        cutSceneToActive.SetActive(false);
    }

    void Update()
    {
        if (playerOnSite == true && Input.GetKeyDown(KeyCode.E))
        {
            cutSceneToActive.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOnSite = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOnSite = false;
        }
    }
}
