using System.Collections.Generic;
using UnityEngine;

public class CityManager : EntityManager<QCity>
{
    [SerializeField] private Entity cityPrefab;

    public override IEnumerable<QCity> QEntities => simulationManager.CurrentState.cities;

    public override Entity EntityPrefab(QCity qCity)
    {
        return cityPrefab;
    }
}