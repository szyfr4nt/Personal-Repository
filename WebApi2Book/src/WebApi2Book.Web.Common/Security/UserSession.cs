﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace WebApi2Book.Web.Common.Security
{
    public class UserSession : IWebUserSession
    {
        public string Firstname => ((ClaimsPrincipal)HttpContext.Current.User)
            .FindFirst(ClaimTypes.GivenName).Value;
        public string Lastname => ((ClaimsPrincipal)HttpContext.Current.User)
            .FindFirst(ClaimTypes.Surname).Value;

        public string Username => ((ClaimsPrincipal)HttpContext.Current.User)
            .FindFirst(ClaimTypes.Name).Value;

        public bool IsInRole(string roleName)
        {
            return HttpContext.Current.User.IsInRole(roleName);
        }
        public Uri RequestUri => HttpContext.Current.Request.Url;

        public string HttpRequestMethod => HttpContext.Current.Request.HttpMethod;

        public string ApiVersionInUse
        {
            get
            {
                const int versionIndex = 2;
                if (HttpContext.Current.Request.Url.Segments.ToList().Count < versionIndex + 1)
                {
                    return string.Empty;
                }
                var apiVersionInUse = HttpContext.Current.Request.Url.Segments[versionIndex]
                    .Replace("/", string.Empty);
                return apiVersionInUse;
            }
        }
    }
}