// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityModel;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("StoreApi")
            };

        /*public static IEnumerable<ApiResource> GetApis =>
            new List<ApiResource>
            {
                new ApiResource("StoreApi")
            };*/

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "StoreApiId",
                    ClientSecrets = { new Secret("StoreApiSecret".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "StoreApi" }
                },
                new Client
                {
                    ClientId = "AccManagementId",
                    ClientSecrets = { new Secret("AccManagementSecret".ToSha256()) },
                    RedirectUris = { "http://localhost:5004/signin-oidc" },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    {
                        "StoreApi",
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Profile
                    },
                    RequireConsent = false,
                }
            };
    }
}