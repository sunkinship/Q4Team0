﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pressurePlate : MonoBehaviour
{

    public bool removeWall;
    public bool bigPlate;
    public bool triggered;

    public GameObject wallToRemove;

    public GameObject player;

    //camera follow stuff
    public PlayerInput playerInput;
    public GameObject cameraToMove;
    private GameObject objectToFocus;
    public float focusTime;
    public float waitToDisable;
    public float speed = 0.0005f;

    private Sprite originalSprite;
    public Sprite pressedSprite;

    [SerializeField] private AudioClip openDoor;
    [SerializeField] private AudioClip plateDown;
    [SerializeField] private float volume;
    private void Start()
    {
        originalSprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(bigPlate == true)
        {
            if (collision.gameObject.tag == "movableObject" && collision.gameObject.name.Contains("BIG") && playerMovement.carryingObject == false)
            {
                triggered = true;
                if(removeWall == true && wallToRemove != null)
                {
                    StartCoroutine(plateWork());
                }
            }
        }
        else if(bigPlate == false)
        {
            if (collision.gameObject.tag == "movableObject" && playerMovement.carryingObject == false)
            {
                AudioManager.Instance.PlaySound(plateDown, 0.5f);
                triggered = true;
                if (removeWall == true && wallToRemove != null)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = pressedSprite;
                    StartCoroutine(plateWork());
                }
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "movableObject")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite;
            triggered = false;
            if (removeWall == true && wallToRemove != null)
            {
                wallToRemove.SetActive(true);
            }
        }
    }

    public IEnumerator plateWork()
    {
        objectToFocus = wallToRemove;
        
        Debug.Log("activate");
        playerMovement.inCutScene = true;
        cameraToMove.GetComponent<CameraFollowPlayer>().enabled = false;
        while (cameraToMove.transform.position != new Vector3(objectToFocus.transform.position.x, objectToFocus.transform.position.y, -10))
        {
            cameraToMove.transform.position = Vector3.MoveTowards(new Vector3(cameraToMove.transform.position.x, cameraToMove.transform.position.y, -10), new Vector3(objectToFocus.transform.position.x, objectToFocus.transform.position.y, -10), speed / Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(waitToDisable);
        AudioManager.Instance.PlaySound(openDoor, 0.5f);
        wallToRemove.SetActive(false);
        yield return new WaitForSeconds(focusTime);
        cameraToMove.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        cameraToMove.GetComponent<CameraFollowPlayer>().enabled = true;
        playerMovement.inCutScene = false;
    }

}
