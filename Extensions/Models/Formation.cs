using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Extensions.Models
{
    [PublishedContentModel("Formation")]
    public class Formation : PublishedContentModel
    {
        public Formation(IPublishedContent content)
            : base(content)
        {

        }
    }
}
