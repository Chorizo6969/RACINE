using UnityEngine;
using UnityEngine.Events;

public class playerAnimationEventReceiver : MonoBehaviour
{
    public UnityEvent Coin1;
    public UnityEvent Coin2;
    public UnityEvent Coin3;

    public void Canard() => Coin1.Invoke();
}