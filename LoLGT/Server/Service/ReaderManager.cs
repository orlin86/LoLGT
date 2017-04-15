


namespace Server.Service
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class ReaderManager
    {
        public static Dictionary<int, string> FileReader(string filePath)
        {
            string jsonDict = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<int, string>>(jsonDict);
        }
    }
}
