namespace Articles.Migrations
{
    using Core;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
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
            seed_cat.Name = "category one";
            seed_cat.UrlSlug = "slug_one";
            context.Categories.AddOrUpdate(seed_cat);

            Category second_seed_category = new Category();
            second_seed_category.Description = "a second category for fewer posts";
            second_seed_category.Name = "seed two";
            second_seed_category.UrlSlug = "seed_two";
            context.Categories.AddOrUpdate(second_seed_category);

            Category third_seed_category = new Category();
            third_seed_category.Description = "third category for seed";
            third_seed_category.Name = "seed category 3";
            third_seed_category.UrlSlug = "seed_category_three";
            context.Categories.AddOrUpdate(third_seed_category);




            Tag seed_tag = new Tag();
            seed_tag.Name = "seed tag";
            seed_tag.UrlSlug = "slug";
            seed_tag.Description = " tag created for seeding";

            Tag seed_tag_2 = new Tag();
            seed_tag_2.Name = "tag2";
            seed_tag_2.UrlSlug = "slug2";
            seed_tag_2.Description = "the second tag created for seed";

            Tag seed_tag_3 = new Tag();
            seed_tag_3.Name = "tag3";
            seed_tag_3.UrlSlug = "tagslug3";
            seed_tag_3.Description = "the third seed tag";

            IList<Tag> tagg = new List<Tag>();
            tagg.Add(seed_tag);
            tagg.Add(seed_tag_2);

            IList<Tag> tags2 = new List<Tag>();
            tags2.Add(seed_tag);
            tags2.Add(seed_tag_3);

            context.Tags.Add(seed_tag);
            context.Tags.Add(seed_tag_2);
            context.Tags.Add(seed_tag_3);



            string generic_short_description = "<p> There are a handful of conventions that seem to stand out above all of the rest. People who are interested in knowing about t.v. shows and movies that will be released over the next year usually pay attention to New York Comicon. People who are interested in video game news look to the Pax conventions eagerly waiting to hear about announcements pertaining to their favorite franchises. However cosplayers wait all year to show case their newest cosplays at Dragoncon. It doesn’t matter if you are looking for panels to teach you how to create a new prop or believe you have what it takes to win a cosplay contest Dragoncon has exactly what you are looking for. <p>";
            string generic_description = generic_short_description + "<p> this is a second paragraph which will only display with the full post";


            for(int i = 1; i < 32; i++)
            {
                Post post = new Post();
                post.Title = "seed post" + i.ToString();
                post.UrlSlug = "seed_post_" + i.ToString();
                post.PostedOn = DateTime.Now.AddDays(i);
                
                if(i < 12)
                {
                    post.Category = seed_cat;
                    post.Tags = tagg;
                }
                else if (i > 11 && i < 25)
                {
                    post.Category = second_seed_category;
                    post.Tags = tags2;
                }
                else
                {
                    post.Category = third_seed_category;
                    post.Tags = tags2;
                }

                post.ShortDescription = generic_short_description;
                post.Description = generic_description;
                post.Published = true;

                context.Posts.Add(post);


            }


            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string name = "Admin";
            string password = "P@ssword1";

            if (!RoleManager.RoleExists(name))
            {
                var roleresult = RoleManager.Create(new IdentityRole(name));



                var user = new ApplicationUser();
                user.UserName = name;
                user.Email = "admin@test.com";
                var adminresult = UserManager.Create(user, password);

                if (adminresult.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, name);
                }
            }




            context.SaveChanges();



            /* old manually created seed posts
            Post seed_post = new Post();
            seed_post.Title = "seed post1 title";
            seed_post.ShortDescription = generic_short_description;
            seed_post.Description = generic_description;
            seed_post.UrlSlug = "seed_post1";
            seed_post.PostedOn = DateTime.Now;
            seed_post.Category = seed_cat;
            seed_post.Published = true;
            seed_post.Tags = tagg;

            Post seed_post2 = new Post();
            seed_post2.Title = "seed post2 title";
            seed_post2.ShortDescription = generic_short_description;
            seed_post2.Description = generic_description;
            seed_post2.UrlSlug = "seed_post2";
            seed_post2.PostedOn = DateTime.Now;
            seed_post2.Category = seed_cat;
            seed_post2.Published = true;
            seed_post2.Tags = tagg;
            
            Post seed_post3 = new Post();
            seed_post3.Title = "seed post3 title";
            seed_post3.ShortDescription = generic_short_description;
            seed_post3.Description = generic_description;
            seed_post3.UrlSlug = "seed_post3";
            seed_post3.PostedOn = DateTime.Now;
            seed_post3.Category = seed_cat;
            seed_post3.Published = true;
            seed_post3.Tags = tagg;
            
            Post seed_post4 = new Post();
            seed_post4.Title = "seed post4 title";
            seed_post4.ShortDescription = generic_short_description;
            seed_post4.Description = generic_description;
            seed_post4.UrlSlug = "seed_post4";
            seed_post4.PostedOn = DateTime.Now;
            seed_post4.Category = seed_cat;
            seed_post4.Published = true;
            seed_post4.Tags = tagg;
            

            Post seed_post5 = new Post();
            seed_post5.Title = "5 a post for a separate category";
            seed_post5.ShortDescription = "<p> There are a handful of conventions that seem to stand out above all of the rest. People who are interested in knowing about t.v. shows and movies that will be released over the next year usually pay attention to New York Comicon. People who are interested in video game news look to the Pax conventions eagerly waiting to hear about announcements pertaining to their favorite franchises. However cosplayers wait all year to show case their newest cosplays at Dragoncon. It doesn’t matter if you are looking for panels to teach you how to create a new prop or believe you have what it takes to win a cosplay contest Dragoncon has exactly what you are looking for. <p>";
            seed_post5.Description = "<p> There are a handful of conventions that seem to stand out above all of the rest. People who are interested in knowing about t.v. shows and movies that will be released over the next year usually pay attention to New York Comicon. People who are interested in video game news look to the Pax conventions eagerly waiting to hear about announcements pertaining to their favorite franchises. However cosplayers wait all year to show case their newest cosplays at Dragoncon. It doesn’t matter if you are looking for panels to teach you how to create a new prop or believe you have what it takes to win a cosplay contest Dragoncon has exactly what you are looking for -- some extra. <p> ";
            seed_post5.UrlSlug = "seed_post5";
            seed_post5.PostedOn = DateTime.Now;
            seed_post5.Category = seed_cat;
            seed_post5.Published = true;
            seed_post5.Tags = tagg;

            Post seed_post6 = new Post();
            seed_post6.Title = "sixth seed post";
            seed_post6.ShortDescription = generic_short_description;
            seed_post6.Description = generic_description;
            seed_post6.UrlSlug = "seed_post6";
            seed_post6.PostedOn = DateTime.Now;
            seed_post6.Category = seed_cat;
            seed_post6.Published = true;
            seed_post6.Tags = tags2;

            Post seed_post7 = new Post();
            seed_post7.Title = "seventh seed post";
            seed_post7.ShortDescription = generic_short_description;
            seed_post7.Description = generic_description;
            seed_post7.UrlSlug = "seed_post7";
            seed_post7.PostedOn = DateTime.Now;
            seed_post7.Category = seed_cat;
            seed_post7.Published = true;
            seed_post7.Tags = tags2;

            Post seed_post8 = new Post();
            seed_post8.Title = "8th seed post";
            seed_post8.ShortDescription = generic_short_description;
            seed_post8.Description = generic_description;
            seed_post8.UrlSlug = "seed_post8";
            seed_post8.PostedOn = DateTime.Now;
            seed_post8.Category = seed_cat;
            seed_post8.Published = true;
            seed_post8.Tags = tags2;

            Post seed_post9 = new Post();
            seed_post9.Title = "9th seed post";
            seed_post9.ShortDescription = generic_short_description;
            seed_post9.Description = generic_description;
            seed_post9.UrlSlug = "seed_post9";
            seed_post9.PostedOn = DateTime.Now;
            seed_post9.Category = seed_cat;
            seed_post9.Published = true;
            seed_post9.Tags = tagg;

            Post seed_post10 = new Post();
            seed_post10.Title = "10th seed post";
            seed_post10.ShortDescription = generic_short_description;
            seed_post10.Description = generic_description;
            seed_post10.UrlSlug = "seed_post_ten";
            seed_post10.PostedOn = DateTime.Now;
            seed_post10.Category = seed_cat;
            seed_post10.Published = true;
            seed_post10.Tags = tagg;

            Post seed_post11 = new Post();
            seed_post11.Title = "11th seed post";
            seed_post11.ShortDescription = generic_short_description;
            seed_post11.Description = generic_description;
            seed_post11.UrlSlug = "seed_post_eleven";
            seed_post11.PostedOn = DateTime.Now;
            seed_post11.Category = third_seed_category;
            seed_post11.Published = true;
            seed_post11.Tags = tags2;

            Post seed_post12 = new Post();
            seed_post12.Title = "11th seed post";
            seed_post12.ShortDescription = generic_short_description;
            seed_post12.Description = generic_description;
            seed_post12.UrlSlug = "seed_post_eleven";
            seed_post12.PostedOn = DateTime.Now;
            seed_post12.Category = seed_cat;
            seed_post12.Published = true;
            seed_post12.Tags = tags2;

           

          

            context.Posts.AddOrUpdate(seed_post);
            context.Posts.AddOrUpdate(seed_post2); 
            context.Posts.AddOrUpdate(seed_post3);
            context.Posts.AddOrUpdate(seed_post4); 
            context.Posts.AddOrUpdate(seed_post5);
            context.Posts.AddOrUpdate(seed_post6);
            context.Posts.AddOrUpdate(seed_post7);
            context.Posts.AddOrUpdate(seed_post8);
            context.Posts.AddOrUpdate(seed_post9);
            context.Posts.AddOrUpdate(seed_post10);
            context.Posts.AddOrUpdate(seed_post11);
            context.Posts.AddOrUpdate(seed_post12);

    */




        }
    }
}
