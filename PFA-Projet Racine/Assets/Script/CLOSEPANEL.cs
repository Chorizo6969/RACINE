using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CLOSEPANEL : MonoBehaviour
{
    [SerializeField] List<GameObject> listPanel;

    public void OnEscape(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started && listPanel.Count != 0)
        {
            foreach (GameObject panel in listPanel)
            {
                panel.SetActive(false);
            }
        }
    }
}
