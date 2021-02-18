using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rootobject test = JsonConvert.DeserializeObject<Rootobject>(File.ReadAllText(@"D:\C#\JsonMassiveToHtml\ConsoleApp1\bin\Debug\netcoreapp3.1\json-Massive.json"));
            
            StringBuilder result = new StringBuilder();
            result.Append($"<Html><head></head><body><form name=\"{test.form.items[0].attributes.name}\">");
              
            foreach(var item in test.form.items){
                StringBuilder input = new StringBuilder();
                if(!string.IsNullOrEmpty(item.attributes.label))
                {
                    input.Append($"<label for=\"{item.attributes.name}\"> {item.attributes.label}</label>"); 
                }
                input.Append("<input");
                if(item.attributes.validationRules != null && item.attributes.validationRules.Length  >0)
                {
                    input.Append($"type=\"{item.attributes.validationRules[0].type}\"");
                }
                else
                {
                   input.Append($"type=\"{item.type}\"");
                }

                if(!string.IsNullOrEmpty(item.attributes.message))
                {
                    input.Append($"messsage=\"{item.attributes.message}\""); 
                }
                if(!string.IsNullOrEmpty(item.attributes.name))
                {
                    input.Append($"name=\"{item.attributes.name}\""); 
                }
                if(!string.IsNullOrEmpty(item.attributes.placeholder))
                {
                    input.Append($"placeholder=\"{item.attributes.placeholder}\""); 
                }
                if(item.attributes.required)
                {
                    input.Append($"required"); 
                }
                if(!string.IsNullOrEmpty(item.attributes.value))
                {
                    input.Append($"value=\"{item.attributes.value}\""); 
                }
                input.Append("/>");
                if(!string.IsNullOrEmpty(item.attributes.ClassName))
                {
                    input.Append($"class=\"{item.attributes.ClassName}\""); 
                }
                if(!string.IsNullOrEmpty(item.attributes.value))
                {
                    input.Append($"value=\"{item.attributes.value}\""); 
                }
                if(item.attributes.disabled)
                {
                    input.Append($"disabled"); 
                }
                if(item.attributes.selected)
                {
                    input.Append($"selected"); 
                }
                if(item.attributes.check)
                {
                    input.Append($"check"); 
                }
                input.Append("/>");

                input.Append("/>");
                result.Append(input.ToString());

            }
            result.Append("</form></body></html>");
            string writePath = @"..\htmlText.html";
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                sw.Write(result.ToString());
            }
            Console.WriteLine();

        }
    }
}
