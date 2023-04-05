using System;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    internal static class PostsRepository
    {
        internal async static Task<List<Post>>GetPostsAsync(){
                using (var db= new apDBcontext() )
                {
                    return await db.Posts.ToListAsync();
                }
        } 

        internal async static Task<Post> GetPostAsyncById(int postId){
            using(var db = new apDBcontext()){
                    return await db.Posts.FirstAsync(x=>x.postId==postId);
            }
        }
        
        internal async static Task<bool> CreatePostAsync(Post addposts)
        {
            using(var db = new apDBcontext()){

                try
                {
                    await db.Posts.AddAsync(addposts);

                    return await db.SaveChangesAsync()>=1;
                }
                catch (System.Exception e)
                {
                   return false;
                }
            }
        }

        internal async static Task<bool> UpdatePostsByI(Post updatepost){
            using (var db =  new apDBcontext())
            {
                try
                {
                     db.Posts.Update(updatepost);
                     return await db.SaveChangesAsync()>=1;
                }
                catch (System.Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeletePostsById(int postID){
            using (var db = new apDBcontext())
            {
                try
                {
                    Post getPost = await GetPostAsyncById(postID);
                    db.Remove(getPost);
                    return await db.SaveChangesAsync()>=1;
                }
                catch (System.Exception e)
                {
                    return false;
                }
            }
        }
    }
}