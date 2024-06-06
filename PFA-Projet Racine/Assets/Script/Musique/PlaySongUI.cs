using UnityEngine;

public class PlaySongUI : MonoBehaviour
{
    [SerializeField]
    private AudioClip _ouverture;

    [SerializeField]
    private AudioClip _femeture;

    [SerializeField]
    private AudioSource AudioSource;

    public void Ouverture()
    {
        AudioSource.PlayOneShot(_ouverture);
    }

    public void Fermeture()
    {
        AudioSource.PlayOneShot(_femeture);
    }
}
