using Microsoft.Extensions.DependencyInjection;
using SoBlog.Application.Convertors;
using SoBlog.Application.Interfaces;
using SoBlog.Application.Senders;
using SoBlog.Application.Services;
using SoBlog.Domain.Interfaces;
using SoBlog.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
			#region Repositories

			services.AddScoped<IAccountRepository, AccountRepository>();

			#endregion

			#region Services

			services.AddScoped<IAccountService, AccountService>();

            #endregion

            #region SiteSetting

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddTransient<IViewRenderService, RenderViewToString>();

            #endregion

        }
    }
}
