using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Editors;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Extensions.Models;

namespace Extensions.Controllers
{
    [PluginController("Team")]
    public class TeamController : UmbracoAuthorizedJsonController
    {
        public dynamic GetSquad()
        {
            var team = Umbraco.TypedContentAtXPath("//Team[coach='" + UmbracoContext.UmbracoUser.Id + "']");
            if (team.Any())
            {
                var playersValue = team.First().GetPropertyValue<string>("team");
                var playerIds = playersValue.Split(new[] { ',' });
                var players = Umbraco.TypedContent(playerIds);

                return players
                    .Select(p => new
                {
                    name = p.Name,
                    photo = Umbraco.TypedMedia(p.GetPropertyValue<string>("photo")).Url,
                    position = Umbraco.TypedContent(p.GetPropertyValue<string>("position")).Name
                }).ToArray();
            }
            return new { };
        }

        public dynamic GetPlayerInfo(string id = "")
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var player =  new Player(Umbraco.TypedContent(id));
                if (player != null)
                {
                    return new
                    {
                        name = player.Name,
                        photo = player.Photo,
                        position = player.Position
                    };
                }
            }
            return new { };
        }
    }
}
