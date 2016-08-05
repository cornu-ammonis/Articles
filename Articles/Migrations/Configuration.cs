namespace Articles.Migrations
{
    using Core;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Articles.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Articles.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            Category seed_cat = new Category();
            seed_cat.Description = "A category crrated for seeding";
            seed_cat.Name = "seeddd";
            Tag seed_tag = new Tag();
            seed_tag.Name = "seed tag";
            seed_tag.UrlSlug = "slug";
            seed_tag.Description = " tag created for seeding";

            Post seed_post = new Post();
            seed_post.Title = "seed post title";
            seed_post.ShortDescription = "<p> this is a short description which is put in between p tag identifiers<p>";
            seed_post.Description = "<p> this is a short description which is put in between p tag identifiers except that its longer<p>";
            seed_post.UrlSlug = "seed_post";
            seed_post.PostedOn = DateTime.Now;
            seed_post.Category = seed_cat;


            IList<Tag> tagg = new List<Tag>();
            tagg.Add(seed_tag);
            seed_post.Tags = tagg;
            seed_post.Published = true;
            context.Posts.AddOrUpdate(seed_post);
            context.SaveChanges();
           
        }
    }
}
