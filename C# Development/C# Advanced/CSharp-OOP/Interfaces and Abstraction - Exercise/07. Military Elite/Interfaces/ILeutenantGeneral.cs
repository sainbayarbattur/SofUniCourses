using System.Collections.Generic;

public interface ILeutenantGeneral : IPrivate, ISoldier
{
    List<ISoldier> Privates { get; }
}