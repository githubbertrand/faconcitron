using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;

/// <summary>
/// Summary description for lemonwayToolBox
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class lemonwayToolBox : System.Web.Services.WebService
{
    private ILog Log = LogManager.GetLogger("loggerForMyApplication");
    public lemonwayToolBox()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public double FibonacciValue(int value)
    {
        double ret = lemonwayTools.StaticHelper.FibonacciValue(value);
        Log.Info(string.Format("FibonacciValue called with \"{0}\" and return \"{1}\".", value, ret));
        return ret;
    }

    [WebMethod]
    //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public string XmlToJsonParser(string Xmlvalue)
    {
        string ret = lemonwayTools.StaticHelper.XmlToJsonParser(Xmlvalue);
        Log.Info(string.Format("FibonacciValue called with \"{0}\" and return \"{1}\".", Xmlvalue, ret));
        return ret;
    }

}
