using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BuildOptionPanel : MonoBehaviour
{
    public GameObject PANELRACINE;
    public GameObject PANEL;
    public GameObject PANEL2MUSIC;
    [SerializeField]
    private Button _desactivateur;
    [SerializeField]
    private Button _desactivateur2;

    public void OnLeftClick(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo );
            if (hitInfo.collider != null && Jkh.Instance.CheckAllBool())
            {
                if (hitInfo.collider.CompareTag("RACINE"))
                {
                    PANELRACINE.SetActive(true);
                }
                else if (hitInfo.collider.CompareTag("building"))
                {
                    if (hitInfo.collider.GetComponentInParent<BuildingCanvas>().gameObject.name == "JukeBox")
                    {
                        PANEL2MUSIC.SetActive(true);
                        StartCoroutine(Delay());
                        PANEL2MUSIC.GetComponent<ClickInfo>().lastBat = hitInfo.collider.GetComponentInParent<BuildingCanvas>().gameObject;
                    }
                    else if (hitInfo.collider.GetComponentInParent<BuildingCanvas>().placeOrNot)
                    {
                        PANEL.SetActive(true);
                        StartCoroutine(Delay2());
                        PANEL.GetComponent<ClickInfo>().lastBat = hitInfo.collider.GetComponentInParent<BuildingCanvas>().gameObject;
                    }
                }
            }
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        _desactivateur2.gameObject.SetActive(true);
    }

    IEnumerator Delay2()
    {
        yield return new WaitForSeconds(0.1f);
        _desactivateur.gameObject.SetActive(true);
    }
}