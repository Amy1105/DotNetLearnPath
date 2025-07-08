using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperDemo.Models
{
    internal class SourceModel
    {
        public int Id { get; set; }

        public string RawText { get; set; }
    }

    public class DestinationModel
    {
        public int Id { get; set; }

        public string FormattedText { get; set; }
    }

    internal class SourceCls
    {
        public int Id { get; set; }

        public string RawText { get; set; }
    }

    public class DestinationCls
    {
        public int Id { get; set; }

        public string FormattedText { get; set; }
    }
}
