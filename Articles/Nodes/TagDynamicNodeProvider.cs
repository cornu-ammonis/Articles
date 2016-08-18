using Articles.Core;
using Articles.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Articles.Nodes
{
    public class TagDynamicNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            foreach (Tag tag in db.Tags)
            {
                DynamicNode dynamicNode = new DynamicNode("Tag_" + tag.UrlSlug, tag.UrlSlug);

                dynamicNode.Title = tag.Name;
                dynamicNode.RouteValues.Add("tag", tag.UrlSlug);
                yield return dynamicNode;
            }
        }
    }
}