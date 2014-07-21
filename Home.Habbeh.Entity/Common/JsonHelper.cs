
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

public class JsonHelper
{
    /// <summary>
    /// JSON Serialization
    /// </summary>
    public static string JsonSerializer<T>(T t)
    {        
        JavaScriptSerializer js = new JavaScriptSerializer();        
        return js.Serialize(t);
    }
    /// <summary>
    /// JSON Deserialization
    /// </summary>
    public static T JsonDeserialize<T>(string jsonString)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        return js.Deserialize<T>(jsonString);    
    }
}