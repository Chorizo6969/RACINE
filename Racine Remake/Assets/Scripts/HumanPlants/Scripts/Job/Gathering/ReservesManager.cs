using System.Collections.Generic;
using UnityEngine;

public class ReservesManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _reservesBois = new();
    [SerializeField] private List<GameObject> _reservesEau = new();
    [SerializeField] private List<GameObject> _reservesPierre = new();
}
