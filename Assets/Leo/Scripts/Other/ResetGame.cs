﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public void Reset()
    {
        PlayerManager.quests.Clear();
        PlayerManager.inventory.Clear();
        PlayerManager.forcedDialogueEncounters.Clear();
        PlayerManager.spawnPoint = new Vector2(0, 0);

        TrustMeter.targetProgress = 0.13f;

        npcInteract.forcedMayorSpeaking = false;
        npcInteract.mayorForcedDialogue = false;

        SwitchMayors.mayorActive = false;

        TriggerFinalQuest.humanQuestCounter = 0;
        TriggerFinalQuest.monsterQuestCounter = 0;
    }
}