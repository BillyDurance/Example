using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace Demo
{

  [System.Web.Services.WebMethod()]
  [System.Web.Script.Services.ScriptMethod()]
  public static string SendHelp(string email)
    {
      return "Fuck you: " + email;
    }



}
