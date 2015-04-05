using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ITypeLookup
   {
      ConstructorInfo GetConstructorInfo(Type t);
      Type GetType(string typeName);
      Type GetType(string typeName, bool throwOnTypeNotFound);
      List<Type> FindAvailableInterfaces(Type interfaceType);      
      T CreateInstanceOfType<T>(Type type) where T : class;
      T CreateInstanceOfType<T>(string typeName) where T : class;
      object CreateInstanceFromType(string typeName);
      object CreateInstanceFromType(Type t);
      IDynamicEnum AbilityTypes { get; }
      IDynamicEnum StateTypes { get; }
      IDynamicEnum StateCategories { get; }
      IDynamicEnum IntentionTypes { get; }
      IDynamicEnum ActionTypes { get; }
      IDynamicEnum ParameterTypes { get; }
      IDynamicEnum ParameterCategories { get; }
      IDynamicEnum ObjectTypes { get; }
      IDynamicEnum ObjectCategories { get; }
      IDynamicEnum TerrainTypes { get; }
      List<ITypeDescription> AllTypesThatImplement(string baseClass);
      List<ITypeDescription> AllTypesThatImplement(Type t);
   }
}
