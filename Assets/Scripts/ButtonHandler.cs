using System;
using System.Runtime.CompilerServices;
using Improbable;
using Improbable.Gdk.Core;
using Improbable.Gdk.PlayerLifecycle;
using Improbable.Gdk.QueryBasedInterest;
using Improbable.Worker.CInterop;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private void Start()
    {
    }

    // private IConnectionHandler ConnectionHandler = new SpatialOSConnectionHandler();
    public void OnStart()
    {
        if (true /*ConnectionHandler.IsConnected()*/)
        {
            Time.timeScale = 1f;
            GameObject.Find("Canvas").SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            PlayerController.gameIsActive = true;
            GameObject.Find("ReticleCanvas").SetActive(true);
        }

    }
}
