using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Articles.Core;
using Articles.Models;

namespace Articles.Nodes
{
    public class CategoryDynamicNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            foreach(Category category in db.Categories)
            {
                DynamicNode dynamicNode = new DynamicNode("Cat_" + category.UrlSlug, category.UrlSlug);
               
                dynamicNode.Title = category.Name;
                dynamicNode.RouteValues.Add("category", category.UrlSlug);
                yield return dynamicNode;
            }

        }

        

    }
}