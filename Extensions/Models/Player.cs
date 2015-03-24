using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Extensions.Models
{
    [PublishedContentModel("Player")]
    public class Player : PublishedContentModel
    {
        UmbracoHelper umbraco;

        public Player(IPublishedContent content)
            : base(content)
        {
            umbraco = new UmbracoHelper(UmbracoContext.Current);
        }

        public string Photo
        {
            get
            {
                return umbraco.TypedMedia(this.GetPropertyValue<string>("photo")).Url;
            }
            
        }

        public string Position
        {
            get
            {
                return umbraco.TypedContent(this.GetPropertyValue<string>("position")).Name;
            }
        }
    }
}
