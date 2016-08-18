using Articles.Models;
using Articles.Core;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Articles.Nodes
{
    public class PostTagDynamicNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            ApplicationDbContext db = new ApplicationDbContext();
           

            foreach (Post post in db.Posts.Include("Tags"))
            {
                foreach(Tag tag in post.Tags)
                {

                    DynamicNode dynamicNode = new DynamicNode();
                    dynamicNode.Title = post.Title + tag.Name;
                    dynamicNode.ParentKey = "Tag_" + tag.UrlSlug;
                    dynamicNode.RouteValues.Add("ti", post.UrlSlug);
                    yield return dynamicNode;

                 }
            }
        }
    }
}