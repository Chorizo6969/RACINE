using UnityEngine;

public class HumanList : MonoBehaviour
{
    [SerializeField]
    private GameObject panel_human;
    [SerializeField]
    private GameObject Button_hide;
    [SerializeField]
    private GameObject Button_show;

    public void Human_Liste()
    {
        panel_human.SetActive(true);
        Button_hide.SetActive(true);
        Button_show.SetActive(false);
    }

    public void Hide_Human_List()
    {
        panel_human.SetActive(false);
        Button_hide.SetActive(false);
        Button_show.SetActive(true);

    }
}
