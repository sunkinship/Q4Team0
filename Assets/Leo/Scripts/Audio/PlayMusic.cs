﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(clip, volume);
    }
}
