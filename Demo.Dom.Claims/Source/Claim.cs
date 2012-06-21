using System.ComponentModel.DataAnnotations;
using NakedObjects;

//Namespace must match that of the auto-generated partial class
namespace Demo.Dom.Claims
{
    //Use this partial class to define actions for the Employer class.
    //Also for methods to enrich the behaviour of properties - such as Validate,
    //Default, or Choices and for class-level attributes such as <IconName>.
    [MetadataType(typeof(Claim_Metadata))]
    public partial class Claim 
    {

        #region Injected Services
        	// This region should contain properties to hold references to any services required by the
        	// object.  Use the 'injs' shortcut to add a new service; 'injc' to add an injected Container

        #endregion

        public string Title()
        {
            var t = new TitleBuilder();
            t.Append(Id).AppendSpace().Append(Name);
            return t.ToString();
        }

        #region Life Cycle Methods
        	// This region should contain any of the 'life cycle' convention methods (such as
        	// Created(), Persisted() etc) called by the framework at specified stages in the lifecycle.


        #endregion

    }

    #region 'Buddy class'
    //This is the so-called 'buddy class' for Employer.  It should have the 
    //same properties as the auto-generated partial Employer class, to which 
    //property-level attributes such as <Hidden> may be added.
    public class Claim_Metadata
    {

    }
    #endregion

}