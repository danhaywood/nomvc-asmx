using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NakedObjects;

namespace Demo.Dom.Claims
{
    public partial class Claim
    {
    
        #region Primitive Properties
        #region Id (Int32)
    [MemberOrder(100)]
        public virtual int  Id {get; set;}

        #endregion
        #region Name (String)
    [MemberOrder(110)]
        public virtual string  Name {get; set;}

        #endregion

        #endregion
    }
}
