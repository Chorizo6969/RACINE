using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TEST : MonoBehaviour
{
    public KeyCode code1;
    public KeyCode code2;
    public KeyCode code3;

    [SerializeField] bool isCheatActive;

    public Listexpedition List2trucs;

    private void Update()
    {
        if (!isCheatActive) return;

        if (Input.GetKey(code1))
        {
            GetComponent<Spawn>().Spawner();
        }
        
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(code2))
        {
            foreach (GameObject button in List2trucs.list)
            {
                button.GetComponent<ChangeColor>().Change();
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(code3))
        {
            foreach (GameObject humanPlant in List2trucs.listHuman)
            {
                humanPlant.GetComponent<HideNSeek>()._startHiding = true;
            }
        }
    }
}