using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IPerformsInitialization
   {
      bool Initialize(ITypeLookup typeLookup);      
   }
}
