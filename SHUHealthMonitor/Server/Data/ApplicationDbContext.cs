﻿using SHUHealthMonitor.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SHUHealthMonitor.Server.Data
{

	//general application dbcontext, used for account storage. 
	///
	/// In VS Package Manager Console (Select Default Project: Hosted_Blazor_WASM_Identity.Server)
	///
	/// Init: (delete "BlazorDB.sqlite3" first)
	/// Clear; Add-Migration InitialCreate -OutputDir "Data/Migrations"; Update-Database;
	///
	/// Add migration:
	/// Clear; Add-Migration ExtraFields -OutputDir "Data/Migrations"
	///
	/// If necessary: Remove-Migration
	///
	/// Update-Database
	///

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<IdentityRole>()
				   .HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
			builder.Entity<IdentityRole>()
				   .HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
		}
	}
}
