using System.Collections.Generic;
using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   public interface SchedulingEngine
   {
      ScheduledWorkItemQueue[] WorkItemQueues {get;set;}
   }

   public interface ScheduledWorkItemQueue
   {
      ScheduledWorkItem ScheduledWorkItem {get;set;}
   }

   public interface ScheduledWorkItem
   {
      World MayAlterWorld { get; set; }
      PlayerOrCharacter MayAlterPlayerOrCharacter { get; set; }
      CharacterState MayAlterCharacterState { get; set; }
      CharacterAction MayResultInCharacterAction { get; set; }
   }

   public interface World
   {
      PlayerOrCharacter[] InfluencesCharacters { get; set; }
      NewActionOrWorkItem ReactionToChange { get; set; }
   }

   public interface PlayerOrCharacter
   {
      World[] CharacterActionsAffectWorld { get; set; }
      Intention ChangeIntention { get; set; }
   }

   public interface CharacterState
   {
      PlayerOrCharacter StateAffectsCharacter { get; set; }
   }

   public interface Intention
   {
      NewActionOrWorkItem ResultingAction { get; set; }
   }

   public interface CharacterAction
   {
      PlayerOrCharacter AffectsCharacter { get; set; }
      CharacterState AltersState { get; set; }
   }

   public interface NewActionOrWorkItem
   {
      SchedulingEngine ScheduleForExecution { get; set; }
   }
}
