using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IControlResponse : IMessage, IHasClassTypeName 
   {
      int ResponseType { get; set; }
      object Response { get; set; }      
   }
}
