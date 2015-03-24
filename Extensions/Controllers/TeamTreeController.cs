using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using umbraco;
using umbraco.BusinessLogic.Actions;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;
using Umbraco.Web;
using Umbraco.Core.Models;

namespace Extensions.Controllers
{
    [PluginController("Team")]
    [Tree("teamApp", "TeamTree", "Team", iconClosed: "icon-doc")]
    public class TeamTreeController : TreeController
    {
        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            throw new NotImplementedException();
        }

        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            var nodes = new TreeNodeCollection();
            if (id == "-1")
            {
                var squad = this.CreateTreeNode("squad", id, queryStrings, "Squad", "icon-users", true);
                var formation = this.CreateTreeNode("formations", id, queryStrings, "Formations", "icon-tactics", true);

                nodes.Add(squad);
                nodes.Add(formation);



            }
            else if (id == "formations")
            {
                var formations = Umbraco.TypedContentAtXPath("//Formation");


                foreach (var f in formations)
                {

                    var item = this.CreateTreeNode(f.Id.ToString(), "formations", queryStrings, f.Name, "icon-tactics", false);
                    nodes.Add(item);
                }

            }
            else if (id == "squad")
            {
                var team = Umbraco.TypedContentAtXPath("//Team[coach='" + UmbracoContext.UmbracoUser.Id + "']");
                if (team.Any())
                {
                    var playersValue = team.First().GetPropertyValue<string>("team");
                    var playerIds = playersValue.Split(new[] { ',' });
                    var players = Umbraco.TypedContent(playerIds);

                    foreach (var player in players)
                    {
                        var item = this.CreateTreeNode(player.Id.ToString(), id, queryStrings, player.Name, "icon-user", false);
                        item.HasChildren = false;
                        nodes.Add(item);
                    }
                }

            }

            return nodes;
        }
    }
}
