using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace synctor
{
    public class Synctor
    {

        public static void ManualSync(string originFilePath, string targetFilePath, Func<JsonDocument, string>? handler = null)
        {
            var originFileText = File.ReadAllText(originFilePath);

            if(originFileText?.Length > 0)
            {
             
                if(handler != null)
                {
                    JsonDocument documents = JsonDocument.Parse(originFileText);

                    _ = handler(documents);
                }
            }
        }

        public static void ManualSync<T>(string originFilePath, string targetFilePath, Func<List<T>, List<T>>? handler = null, bool insertIfNotExists = false)
        {
            var originFileText = File.ReadAllText(originFilePath);

            if (originFileText?.Length > 0)
            {

                if (handler != null)
                {
                    List<T>? documents = JsonSerializer.Deserialize<List<T>>(originFileText);

                    if (documents?.Count > 0) { 

                        List<T> transformedDocuments = handler(documents);

                        var targetExists = File.Exists(targetFilePath);

                        if(insertIfNotExists && !targetExists)
                        {

                            File.WriteAllText(targetFilePath, JsonSerializer.Serialize(transformedDocuments));
                        }
                    }
                }
            }
        }

    }
}
