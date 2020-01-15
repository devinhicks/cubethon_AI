﻿using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public GameManager gameManager;

    // When player hits goal, level is complete
    private void OnTriggerEnter()
    {
        gameManager.ComepleteLevel();
    }
}