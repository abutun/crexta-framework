using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IControlCommand : IHasParameters 
   {
      IIntention NewIntention { get; set; }      
   }
}
