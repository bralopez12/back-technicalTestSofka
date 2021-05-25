using back_technicalTest.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace back_technicalTest.Entites
{
    public class GreeterRequest
    {
        public IdiomType IdiomType{ get; set; }
        public ResponsesType ResponsesType{ get; set; }
    }
}
