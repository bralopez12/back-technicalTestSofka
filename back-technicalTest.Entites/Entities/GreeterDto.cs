using back_technicalTest.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace back_technicalTest.Core.Entities
{
    public class GreeterDto
    {
        public string Name { get; set; }
        public string Idiom { get; set; }

        [JsonIgnore]
        public ResponseType ResponseType { get; set; }
    }
}
