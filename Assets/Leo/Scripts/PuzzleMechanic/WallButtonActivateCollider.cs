﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WallButtonActivateCollider : MonoBehaviour
{
    public GameObject itemToEnable;
    public float time;
    public PlayerInput playerInput;
    public bool canPressButton;

    public GameObject cameraToMove;
    private GameObject objectToFocus;
    public GameObject player;
    public GameObject mirrorPlayer;

    public float focusTime;
    public float waitToDisable;

    public float speed = 0.0005f;

    private bool canActivatecanPressButton;

    public bool mirrorScene;

    public void Start()
    {
        objectToFocus = itemToEnable;
        canActivatecanPressButton = true;
    }

    private void Update()
    {
        if (canPressButton == true && playerInput.actions["Interact"].triggered)
        {
            canPressButton = false;
            StartCoroutine(ButtonWork());
        }
    }

    //public void OnTriggereNTER2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag.Equals("Player"))
    //    {
    //        Debug.Log("entered collider");
    //        canPressButton = true;
    //    }
    //}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("interactionZone"))
        {
            Debug.Log("entered collider");
            canPressButton = true;
        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "interactionZone")
        {
            Debug.Log("Leaving collider");
            canPressButton = false;
        }
    }

    public IEnumerator ButtonWork()
    {
        Debug.Log("button pressed");
        if (mirrorScene)
        {
            mirrorPlayer.GetComponent<playerMovement>().enabled = false;
        }
        player.GetComponent<playerMovement>().enabled = false;
        cameraToMove.GetComponent<CameraFollowPlayer>().enabled = false;
        canActivatecanPressButton = false;
        while (cameraToMove.transform.position != new Vector3(objectToFocus.transform.position.x, objectToFocus.transform.position.y, -10))
        {
            cameraToMove.transform.position = Vector3.MoveTowards(new Vector3(cameraToMove.transform.position.x, cameraToMove.transform.position.y, -10), new Vector3(objectToFocus.transform.position.x, objectToFocus.transform.position.y, -10), speed / Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(waitToDisable);
        itemToEnable.SetActive(true);
        yield return new WaitForSeconds(focusTime);
        cameraToMove.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        cameraToMove.GetComponent<CameraFollowPlayer>().enabled = true;
        if (mirrorScene)
        {
            mirrorPlayer.GetComponent<playerMovement>().enabled = true;
        }
        player.GetComponent<playerMovement>().enabled = true;
        //yield return new WaitForSeconds(time);
        //canActivatecanPressButton = true;
        //itemToDisable.SetActive(true);
    }
}
