using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using System;

      var MyAllowSpecificOrigins = "CORSPolicy";

        var builder = WebApplication.CreateBuilder(args);
        
            builder.Services.AddCors(option=> {
                option.AddPolicy(MyAllowSpecificOrigins,
                builder=> builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed((host)=>true)
                    //.WithOrigins("http://localhost:3000","http://192.168.8.105:3000");}
                 );
       });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(swaggerGenOptionsExtensions =>{
            swaggerGenOptionsExtensions.SwaggerDoc("v1",new OpenApiInfo{Title ="ASP.NET React Tutorial ", Version = "v1"});  
        });

        var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(
                    swaggerUIOptions=>{
                    swaggerUIOptions.DocumentTitle="ASP.NET React Tutorial";
                    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json","Wep Api serving and ");
                    swaggerUIOptions.RoutePrefix= string.Empty;
                    }
                );
        app.UseHttpsRedirection();
        app.UseCors(MyAllowSpecificOrigins);

        app.MapGet("/get-all-post", async () => await PostsRepository.GetPostsAsync()).WithTags("posts 2endpoints");
        app.MapGet("/get-post-id/{postId}",async(int postId)=>{
                Post returnpost  = await PostsRepository.GetPostAsyncById(postId);
                if (returnpost!=null)
                {
                  return Results.Ok(returnpost);  
                }
                else{
                    return Results.BadRequest();
                }
        }).WithTags("posts endpoints");
        app.MapPost("/create-post",async(Post addpost)=>{
                bool createsuccesfull = await PostsRepository.CreatePostAsync(addpost);
                if (createsuccesfull)
                {
                    return Results.Ok("Added succesfull");
                }
                else {
                    return Results.BadRequest("Error not added");
                }
        }).WithTags("posts endpoints");
        app.MapPut("/update-post",async(Post updatepost)=>{
            bool updatePost = await PostsRepository.UpdatePostsByI(updatepost);
            if (updatePost)
            {
                return Results.Ok("updated");
            }
            else{
                return Results.BadRequest();
            }
        }).WithTags("posts endpoints");
        app.MapDelete("/delete-byid/{postID}",async(int postID)=>{
        bool deletepost = await PostsRepository.DeletePostsById(postID);
        if (deletepost)
        {
            return  Results.Ok("deleted sucsesfull");
        }
        else {
            return Results.BadRequest("not found");
        }
    }).WithTags("posts endpoints");

app.Run();
