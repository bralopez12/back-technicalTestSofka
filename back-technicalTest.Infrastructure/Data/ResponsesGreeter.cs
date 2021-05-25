using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace back_technicalTest.Infrastructure.Data
{
    public partial class ResponsesGreeter
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public string Response { get; set; }
        public int Idiom { get; set; }

        public virtual Idioms IdiomNavigation { get; set; }
    }
}
