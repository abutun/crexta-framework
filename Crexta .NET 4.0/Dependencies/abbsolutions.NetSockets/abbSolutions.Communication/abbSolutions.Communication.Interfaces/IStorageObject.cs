using System;
using System.Collections.Generic;
using System.ComponentModel;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
    [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
    public interface IStorageObject<TGameType, TStorageType>
        where TGameType : class, new()
        where TStorageType : class, new()
    {
        TStorageType CreateStorageObjectFromGameObject(TGameType gameObject);
        T CreateStorageObject<T>() where T : class, ISuppliesID, new();
        TGameType CreateGameObjectFromStorageObject(TStorageType storageObject);
        TGameType CreatePersistentGameObject();
    }
}
