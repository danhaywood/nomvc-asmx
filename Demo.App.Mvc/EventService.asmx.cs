using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Demo.Dom.Claims;
using NakedObjects.Architecture.Adapter;
using NakedObjects.Architecture.Reflect;
using NakedObjects.Architecture.Security;
using NakedObjects.Core.Context;
using NakedObjects.Core.Security;
using NakedObjects.Reflector.Spec;
using NakedObjects.Web.Mvc.Html;

namespace Demo.App.Mvc
{
    /// <summary>
    /// Summary description for EventService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EventService : System.Web.Services.WebService
    {

        [WebMethod]
        public string UpdateClaim(int id, string name)
        {
            NakedObjectsContext.Instance.SetSession(new WindowsSession(User));
            var claims = GetService<ClaimFactory>();
            NakedObjectsContext.ObjectPersistor.StartTransaction();
            try
            {
                var claim = claims.Find(id);
                claim.Name = name;
                return "OK";
            }
            finally
            {
                NakedObjectsContext.ObjectPersistor.EndTransaction();
            }
        }

        public static T GetService<T>()
        {
            foreach (var s in GetAllServices())
            {
                if (s is T)
                {
                    return (T) s; 
                }
            }
            return default(T);
        }

        public static List<object> GetAllServices()
        {
            return NakedObjectsContext.ObjectPersistor.GetServices()
                    .Where(x => GetActions(x).Any()).Select(x => x.Object).ToList();
        }

        public static IEnumerable<INakedObjectAction> GetActions(INakedObject nakedObject)
        {
            return nakedObject.Specification.GetObjectActions(NakedObjectActionConstants.USER)
                .OfType<NakedObjectActionImpl>()
                .Union(nakedObject.Specification.GetObjectActions(NakedObjectActionConstants.USER)
                .OfType<NakedObjectActionSet>()
                .SelectMany(set => (IEnumerable<INakedObjectAction>)set.Actions))
                .Where(a => a.IsUsable(CurrentSession, nakedObject).IsAllowed)
                .Where(a => a.IsVisible(CurrentSession, nakedObject));
        }

        static ISession CurrentSession
        {
            get
            {
                return NakedObjectsContext.Session;
            }
        }
    }
}
