﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public static void Reset()
    {
        PlayerManager.quests.Clear();
        PlayerManager.inventory.Clear();
        //PlayerManager.finishedQuests.Clear();
        PlayerManager.forcedDialogueEncounters.Clear();
        PlayerManager.spawnPoint = new Vector2(0.2f, 0.3f);

        TrustMeter.targetProgress = 0.13f;

        npcInteract.forcedMayorSpeaking = false;
        npcInteract.mayorForcedDialogue = false;

        SwitchMayors.mayorActive = false;

        TriggerFinalQuest.humanQuestCounter = 0;
        TriggerFinalQuest.monsterQuestCounter = 0;

        EnableMirrorButton.buttonEnabled = false;
        EnableMirrorButton.buttonPressed = false;
        DestroyDoorToMirror.doorDestroyed = false;

        playerMovement.inCutScene = false;
        playerMovement.lastFacingDirection = "DOWN";

        DisableRock.leftHouse = false;

        EnableBarnMaze.barnQuest = false;

        vourgnrhgghgggg.vampQuestSwap = false;
        vourgnrhgghgggg.vampQuestSwap2 = false;

        ItemGiver.harryGaveHay = false;

    }
}
