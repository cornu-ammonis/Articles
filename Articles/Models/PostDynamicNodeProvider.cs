using Articles.Core;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Articles.Models
{
    public class PostDynamicNodeProvider : DynamicNodeProviderBase
    {

        

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationDbContext db2 = new ApplicationDbContext();

                foreach (Post post in db.Posts.Include("Category"))
                {

                   // string cat_key = db2.Posts.Find(post.Id).Category.UrlSlug;
                    DynamicNode dynamicNode = new DynamicNode();
                    dynamicNode.Title = post.Title;
                   // string parentkey = "cat" + cat_key;
                    dynamicNode.ParentKey = "Cat_" + post.Category.UrlSlug;
                    dynamicNode.RouteValues.Add("ti", post.UrlSlug);
                   
                    yield return dynamicNode;
                }
            }

        }
    }
}