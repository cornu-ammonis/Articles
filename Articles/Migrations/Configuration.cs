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
            Tag seed_tag_2 = new Tag();
            seed_tag_2.Name = "tag2";
            seed_tag_2.UrlSlug = "slug2";
            seed_tag_2.Description = "the second tag created for seed";

            Category second_seed_category = new Category();
            second_seed_category.Description = "a second category for fewer posts";
            second_seed_category.Name = "seed two";
            second_seed_category.UrlSlug = "seed_two";
            context.Categories.AddOrUpdate(second_seed_category);

            /*
            Post seed_post = new Post();
            seed_post.Title = "seed post title";
            seed_post.ShortDescription = "<p> this is a short description which is put in between p tag identifiers<p>";
            seed_post.Description = "<p> this is a short description which is put in between p tag identifiers except that its longer<p>";
            seed_post.UrlSlug = "seed_post";
            seed_post.PostedOn = DateTime.Now;
            seed_post.Category = seed_cat;

            Post seed_post2 = new Post();
            seed_post2.Title = "2seed post title";
            seed_post2.ShortDescription = "<p> 2 this is a short description which is put in between p tag identifiers<p>";
            seed_post2.Description = "<p> 2this is a short description which is put in between p tag identifiers except that its longer<p>";
            seed_post2.UrlSlug = "seed_post2";
            seed_post2.PostedOn = DateTime.Now;
            seed_post2.Category = seed_cat;
            
            Post seed_post3 = new Post();
            seed_post3.Title = "3seed post title";
            seed_post3.ShortDescription = "<p> 3 this is a short description which is put in between p tag identifiers<p>";
            seed_post3.Description = "<p> 3this is a short description which is put in between p tag identifiers except that its longer<p>";
            seed_post3.UrlSlug = "seed_post3";
            seed_post3.PostedOn = DateTime.Now;
            seed_post3.Category = seed_cat;
            
            Post seed_post4 = new Post();
            seed_post4.Title = "4seed post title";
            seed_post4.ShortDescription = "<p> 4 this is a short description which is put in between p tag identifiers<p>";
            seed_post4.Description = "<p> 4this is a short description which is put in between p tag identifiers except that its longer<p>";
            seed_post4.UrlSlug = "seed_post4";
            seed_post4.PostedOn = DateTime.Now;
            seed_post4.Category = seed_cat;
            */

            Post seed_post5 = new Post();
            seed_post5.Title = "5 a post for a separate category";
            seed_post5.ShortDescription = "<p> There are a handful of conventions that seem to stand out above all of the rest. People who are interested in knowing about t.v. shows and movies that will be released over the next year usually pay attention to New York Comicon. People who are interested in video game news look to the Pax conventions eagerly waiting to hear about announcements pertaining to their favorite franchises. However cosplayers wait all year to show case their newest cosplays at Dragoncon. It doesn’t matter if you are looking for panels to teach you how to create a new prop or believe you have what it takes to win a cosplay contest Dragoncon has exactly what you are looking for. <p>";
            seed_post5.Description = "<p> There are a handful of conventions that seem to stand out above all of the rest. People who are interested in knowing about t.v. shows and movies that will be released over the next year usually pay attention to New York Comicon. People who are interested in video game news look to the Pax conventions eagerly waiting to hear about announcements pertaining to their favorite franchises. However cosplayers wait all year to show case their newest cosplays at Dragoncon. It doesn’t matter if you are looking for panels to teach you how to create a new prop or believe you have what it takes to win a cosplay contest Dragoncon has exactly what you are looking for -- some extra. <p> ";
            seed_post5.UrlSlug = "seed_post5";
            seed_post5.PostedOn = DateTime.Now;
            seed_post5.Category = second_seed_category;
            seed_post5.Published = true;

            IList<Tag> tagg = new List<Tag>();
            tagg.Add(seed_tag);
            tagg.Add(seed_tag_2);
            /*  seed_post.Tags = tagg;
              seed_post2.Tags = tagg;
              seed_post.Published = true;
              seed_post2.Published = true;
              context.Posts.AddOrUpdate(seed_post);
              context.Posts.AddOrUpdate(seed_post2); 
            seed_post3.Tags = tagg;
            seed_post4.Tags = tagg;
            seed_post3.Published = true;
            seed_post4.Published = true;
            context.Posts.AddOrUpdate(seed_post3);
            context.Posts.AddOrUpdate(seed_post4); */
            seed_post5.Tags = tagg;
            context.Posts.AddOrUpdate(seed_post5);

            context.SaveChanges();
           
        }
    }
}
