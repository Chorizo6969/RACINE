using UnityEngine;

public class PlaySongUI : MonoBehaviour
{
    [SerializeField]
    private AudioClip _ouverture;

    [SerializeField]
    private AudioClip _femeture;

    [SerializeField]
    private AudioSource AudioSource;

    private int id = 1;

    public void Ouverture()
    {
        if (gameObject.layer == 14)
        {
            if (Jkh.Instance.BOOLISTEBUILDINGPANEL)
            {
                AudioSource.PlayOneShot(_ouverture);
                id = 2;
            }
            else if (gameObject.layer == 14)
            {
                Fermeture();
            }
        }

        AudioSource.PlayOneShot(_ouverture);
    }

    public void Fermeture()
    {
        if (!Jkh.Instance.BOOLISTEBUILDINGPANEL)
        {
            AudioSource.PlayOneShot(_femeture);
            id = 1;
        }
        else if (gameObject.layer == 14)
        {
            Ouverture();
        }
        AudioSource.PlayOneShot(_femeture);
    }
}
