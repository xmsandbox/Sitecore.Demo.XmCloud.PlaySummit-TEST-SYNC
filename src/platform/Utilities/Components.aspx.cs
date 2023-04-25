using System;
using System.Collections.Generic;
using Sitecore.Data.Items;
using Spe.Core.Host;

namespace Sitecore.Demo.Edge.Website.Utilities
{
	public partial class Components : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                using (ScriptSession scriptSession = ScriptSessionManager.NewSession("Default", true))
                {
                    Item speScriptItem = Sitecore.Context.Database.GetItem("/sitecore/system/Modules/PowerShell/Script Library/PLAY/Update Components LibraryId");
                    string script = speScriptItem["Script"];

                    var results = new List<object>();
                    if (!string.IsNullOrEmpty(script))
                    {
                        results = scriptSession.ExecuteScriptPart(script, false);
                    }

                    foreach (var result in results)
                    {
                        Response.Write(result);
                    }
                }
            }
        }
    }
}
