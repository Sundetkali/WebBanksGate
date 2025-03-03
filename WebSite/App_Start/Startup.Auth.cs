﻿using System;
using System.Linq;
using System.Web.Mvc;
using BanksGateDataModel.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace WebSite
{
    public partial class Startup
    {
        // Дополнительные сведения о настройке аутентификации см. на странице https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Настройка контекста базы данных, диспетчера пользователей и диспетчера входа для использования одного экземпляра на запрос
            // app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            // app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Включение использования файла cookie, в котором приложение может хранить информацию для пользователя, выполнившего вход,
            // и использование файла cookie для временного хранения информации о входах пользователя с помощью стороннего поставщика входа
            // Настройка файла cookie для входа
            // app.UseCookieAuthentication(new CookieAuthenticationOptions
            // {
            //     AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //     LoginPath = new PathString("/Account/Login"),
            //     LogoutPath = new PathString("/Account/LogOff"),
            //     ExpireTimeSpan = new TimeSpan(0, 30, 0),
            //     SlidingExpiration = true,
            //     Provider = new CookieAuthenticationProvider
            //     {
            //         // Позволяет приложению проверять метку безопасности при входе пользователя.
            //         // Эта функция безопасности используется, когда вы меняете пароль или добавляете внешнее имя входа в свою учетную запись.  
            //         // OnValidateIdentity = context =>
            //         // {
            //         //     // return SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ADM_UserSecurityViewModel, long>(
            //         //     //     validateInterval: TimeSpan.FromMinutes(30),
            //         //     //     regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager),
            //         //     //     r => Convert.ToInt64(r.Claims.First(c => c.Type == "UserId").Value))(context);
            //         // }
            //     }
            // });
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Позволяет приложению временно хранить информацию о пользователе, пока проверяется второй фактор двухфакторной проверки подлинности.
            //app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Позволяет приложению запомнить второй фактор проверки имени входа. Например, это может быть телефон или почта.
            // Если выбрать этот параметр, то на устройстве, с помощью которого вы входите, будет сохранен второй шаг проверки при входе.
            // Точно так же действует параметр RememberMe при входе.
            //app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        }
    }
}