using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Articles.Models;
using Articles.Core;

namespace Articles.Core
{
    class BlogRepository : IBlogRepository
    {

        public ApplicationDbContext db;

        // ninject constructor 
        public BlogRepository(ApplicationDbContext database)
        {
            db = database;
        }

        public IList<Post> Posts(int pageNo, int pageSize) {

            List<Post> posts = new List<Post>();

            IEnumerable<Post> post_query =
                (from p in db.Posts
                 where p.Published == true
                 orderby p.PostedOn descending
                 select p)
                .Skip(pageNo * pageSize).Take(pageSize);

            foreach (Post post in post_query)
            {
                posts.Add(post);
            }

            return posts;


            }

        public IList<Post> PostsForCategory(string categorySlug, int pageNo, int pageSize)
        {
            List<Post> posts = new List<Post>();

            IEnumerable<Post> post_query =
                (from p in db.Posts
                 where p.Published == true
                 where p.Category.UrlSlug.Equals(categorySlug)
                 orderby p.PostedOn descending
                 select p)
                 .Skip(pageNo * pageSize).Take(pageSize);
            
            foreach (Post post in post_query)
            {
                posts.Add(post);
            }

            return posts;
        }

        public IList<Post> PostsForTag(string tagSlug, int pageNo, int pageSize)
        {
            List<Post> posts = new List<Post>();

            IEnumerable<Post> post_query =
                (from p in db.Posts
                 where p.Published == true
                 where p.Tags.Any(t => t.UrlSlug.Equals(tagSlug))
                 orderby p.PostedOn descending
                 select p)
                 .Skip(pageNo * pageSize).Take(pageSize);

            foreach (Post post in post_query)
            {
                posts.Add(post);
            }

            return posts;
        }

        public IList<Post> PostsForSearch(string search, int pageNo, int pageSize)
        {
            List<Post> posts = new List<Post>();

            IEnumerable<Post> post_query =
                (from p in db.Posts
                 where p.Published == true &&
                 ( p.Title.Contains(search) || p.Category.Name.Equals(search) || p.Tags.Any(t => t.Name.Equals(search)))
                 orderby p.PostedOn descending
                 select p)
                 .Skip(pageNo * pageSize).Take(pageSize);

            foreach (Post post in post_query)
            {
                posts.Add(post);
            }

            return posts;
        }

        public int TotalPosts()
        {
            int total = 0;
            IEnumerable<Post> p_query =
                from p in db.Posts
                where p.Published == true
                select p;

            foreach (Post post in p_query)
            {
                total = total + 1;
            }

            return total;

        }

        public int TotalPostsForCategory(string categorySlug)
        {
            int total = 0;
            IEnumerable<Post> p_query =
                from p in db.Posts
                where p.Published == true && p.Category.UrlSlug.Equals(categorySlug)
                select p;

            foreach (Post post in p_query)
            {
                total = total + 1;
            }

            return total;
               
        }

        public int TotalPostsForTag(string tagSlug)
        {
            int total = 0;
            IEnumerable<Post> p_query =
                from p in db.Posts
                where p.Published == true && p.Tags.Any(t => t.UrlSlug.Equals(tagSlug))
                select p;

            foreach (Post post in p_query)
            {
                total = total + 1;
            }

            return total;
        }

        public int TotalPostsForSearch(string search)
        {
            int total = 0;

            IEnumerable<Post> p_query =
                from p in db.Posts
                where p.Published == true
                where p.Title.Contains(search) || p.Category.Name.Equals(search) || p.Tags.Any(t => t.Name.Equals(search))
                select p;

            foreach (Post post in p_query)
            {
                total = total + 1;
            }

            return total;
        }

        //theres probably a better way to implement this without the unecessary loop -- maybe dont use LINQ
        public Category Category(string categorySlug)
        {
            Category category_instance = null;
            /*
            IEnumerable<Category> c_query =
                from c in db.Categories
                where c.UrlSlug.Equals(categorySlug)
                select c;

            foreach (Category category in c_query)
            {
                category_instance = category;
            } */

            // ** implementation without loop 
            category_instance = db.Categories.FirstOrDefault(c => c.UrlSlug.Equals(categorySlug));

            return category_instance;
        }

        public Tag Tag(string tagSlug)
        {
            Tag tag_instance = null;

            tag_instance = db.Tags.FirstOrDefault(t => t.UrlSlug.Equals(tagSlug));
            return tag_instance;
        }

        public Post Post(int year, int month, string titleSlug)
        {
             Post post = null;
            try
            {
                post = db.Posts.SingleOrDefault(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug.Equals(titleSlug));
                
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Post selection failed due to title and date-published duplication");
            }
            return post;

           
        }


        public IList<Category> Categories()
        {
            List<Category> categories = new List<Category>();
            IEnumerable<Category> c_query =
                from c in db.Categories
                orderby c.Name
                select c;

            foreach (Category category in c_query)
            {
                categories.Add(category);
            }

            return categories;
        }

        public IList<Tag> Tags()
        {
            List<Tag> tags = new List<Tag>();
            IEnumerable<Tag> t_query =
                from t in db.Tags
                orderby t.Name
                select t;

            foreach (Tag tag in t_query)
            {
                tags.Add(tag);
            }

            return tags;
        }
    }
}
