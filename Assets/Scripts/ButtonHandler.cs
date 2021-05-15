using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
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
