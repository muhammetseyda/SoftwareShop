// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace SoftwareShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
          new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission","CatalogWritePermission"}},
          new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"}},
          new ApiResource("ResourceOrdering"){Scopes={"OrderingFullPermission"}},
          new ApiResource(IdentityServerConstants.LocalApi.ScopeName),
        };
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderingFullPermission","Full authority for order operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName),

        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId="SoftwareShopVisitorId",
                ClientName="Software Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("softwareshopsecret".Sha256())},
                AllowedScopes={ "DiscountFullPermission" }
            },
            //Manager
            new Client
            {
                ClientId="SoftwareShopManagerId",
                ClientName="Software Shop Manager User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("softwareshopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission" }
            },
            //Admin
            new Client
            {
                ClientId="SoftwareShopAdminId",
                ClientName="Software Shop Admin User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("softwareshopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderingFullPermission",
                    "CargoFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                },
                AccessTokenLifetime=600
            }
        };
    }
}