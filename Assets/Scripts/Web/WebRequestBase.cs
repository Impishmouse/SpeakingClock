using System;
using System.Collections.Generic;

namespace Web
{
    public class WebRequestBase
    {
        public string Method { get; set; } = string.Empty;
        
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        
        public Action<RequestResultData> Callback { get; set; }
        
    }
}