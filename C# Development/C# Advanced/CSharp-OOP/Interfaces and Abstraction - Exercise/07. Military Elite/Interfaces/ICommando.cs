using System.Collections.Generic;

public interface ICommando : ISpecialisedSoldier, ISoldier
{
    List<IMission> Missions { get; }
}