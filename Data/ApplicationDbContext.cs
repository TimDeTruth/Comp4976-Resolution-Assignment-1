using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResolutionAssignment.Models;

namespace ResolutionAssignment.Data;

// public class ApplicationDbContext : IdentityDbContext
// {
//     // public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//     //     : base(options)
//     // {
//     // }


public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Resolution> Resolutions { get; set; }
    public DbSet<Response> ResolutionItems { get; set; }

    
    protected override void OnModelCreating(ModelBuilder builder)//thsi is where we see the database.
    {
        base.OnModelCreating(builder);//pass it a builder object

        builder.Entity<Resolution>().HasKey(r => r.ResolutionId);//this is the primary key
        builder.Entity<Resolution>().Property(r => r.ResolutionId).ValueGeneratedOnAdd();//
        builder.Entity<Resolution>().Property(r => r.CreationDate);//this is the creation date
        builder.Entity<Resolution>().Property(r => r.Abstract).IsRequired();//this is a required field
        builder.Entity<Resolution>().Property(r => r.Status).HasDefaultValue(Resolution.ResolutionStatus.pending);
        builder.Entity<Resolution>().Property(r => r.UserId);
        
        builder.Entity<Response>().HasKey(r => r.ResponseId);//this is the primary key
        builder.Entity<Response>().Property(r => r.UserId);
        builder.Entity<Response>().Property(r => r.ResolutionId);
        builder.Entity<Response>().Property(r => r.ResponseDate);//this is a required field
        builder.Entity<Response>().Property(r => r.ResponseText).IsRequired();//this is a required field
        builder.Entity<Response>().Property(r => r.ResponseStatus).HasDefaultValue(Response.ResponseType.Maybe);

        builder.Entity<Resolution>().ToTable("Resolution");//this is the table name
        builder.Entity<Response>().ToTable("Response");//this is the table name
        // Use seed method here
        builder.Seed();//call the extension method HERE, extension method is in ModelBuilderExtensions.cs
    }



}
