using System.Collections.Generic;

public interface IEngineer : ISpecialisedSoldier,ISoldier
{
    List<IRepair> Repairs { get; }
}