using Microsoft.EntityFrameworkCore;
using SoBlog.Domain.Entities.Account;
using SoBlog.Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Infra.Data.Context
{
	public class SoBlogDbContext : DbContext
	{
		public SoBlogDbContext(DbContextOptions options) : base(options)
		{
		}

		#region Account

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<RolePermission> RolePermissions { get; set; }

		#endregion

		#region Posts

		public DbSet<Category> Categories { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
			{
				relation.DeleteBehavior = DeleteBehavior.Restrict;
			}

			base.OnModelCreating(modelBuilder);
		}

	}
}
