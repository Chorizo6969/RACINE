using System.Collections.Generic;
using UnityEngine;

public class HomeAssigner : MonoBehaviour
{
    public void FindHouse(HumanPlants pnj)
    {
        List<BuildingBase> houses = BuildingManager.Instance.Buildings[typeof(Home)];

        int random = Random.Range(0, houses.Count);
        Home choosedHome = houses[random] as Home;

        // If the home can still be occupied, we assign it.
        if (choosedHome != null && choosedHome.AssignHome(pnj)) pnj.Maison = choosedHome.transform;

        else FindHouse(pnj); // If not, we try assigning another.
    }
}
