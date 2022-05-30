﻿using FindX.WebApi.Model;
using FindX.WebApi.Settings;
using Microsoft.Extensions.DependencyInjection;
using AspNetCore.Identity.MongoDbCore.Extensions;
using MongoDB.Driver;

namespace FindX.WebApi.Extenstions
{
	public static class Database
	{
		public static void RegisterMongoDb(this WebApplicationBuilder builder)
		{
			var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
			builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
			(
					mongoDbSettings.ConnectionString, mongoDbSettings.ConnectionString
			);
			builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(mongoDbSettings.ConnectionString));
		}
	}
}
