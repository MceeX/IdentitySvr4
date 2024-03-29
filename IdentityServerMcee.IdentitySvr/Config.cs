﻿using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServerMcee.IdentitySvr
{
  public class Config
  {
    public static List<TestUser> GetUsers()
    {
      return new List<TestUser>
      {
        new TestUser
        {
          SubjectId = "1",
          Username = "sindile@gmail.com",
          Password = "sindile"
        },
        new TestUser
        {
          SubjectId = "2",
          Username = "Sinken",
          Password = "password"
        },
        new TestUser
        {
          SubjectId = "3",
          Username = "Mcee",
          Password = "getgoals"
        }
      };
    }
    public static IEnumerable<ApiScope> GetApiScopes()
    {
      return new List<ApiScope>
      {
        new ApiScope("bankOMceeAPI",".Net app scope")
      };
    }
    
    public static IEnumerable<ApiResource> GetAllApiResources()
    {
      return new List<ApiResource>
      {
        new ApiResource("BankOMceeAPI","Customer API for BankOAPI")
      };
    }
    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
      return new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
    };
    }

    public static IEnumerable<Client> GetClients()
    {
      return new List<Client>
      {

        new Client
        {
          ClientId = "adminapi",
          AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
          ClientSecrets =
          {
            new Secret("secret".Sha256())
          },
          AllowedScopes = {"offline_access"},
        },
        new Client
        {
          ClientId = "adminUIclient",
          AllowedGrantTypes = GrantTypes.Implicit,
          RedirectUris = new [] { "https://localhost:7021", "https://localhost:7021/signin-oidc" },
          ClientSecrets =
          {
            new Secret("secret".Sha256())
          },
           AllowedScopes = new List<string>{IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile},
           AllowAccessTokensViaBrowser = true
        },
        new Client
        {
          ClientId = "client",
          AllowedGrantTypes = GrantTypes.ClientCredentials,
          ClientSecrets =
          {
            new Secret("secret".Sha256())
          },
          AllowedScopes = {"offline_access"},
        },
        //Resource owner password grant type
        new Client
        {
          ClientId = "ro.client",
          AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
          ClientSecrets =
          {
            new Secret("secret".Sha256())
          },
          AllowedScopes = { "bankOMceeAPI" }
        },

        //Implicit flow grant type
        new Client
        {
          ClientId = "angular_spa",
          ClientName = "Angular SPA",
          AllowedGrantTypes = GrantTypes.Implicit,
          //RedirectUris = { "http://localhost:4200/sign-oidc" },
          RedirectUris = { "http://localhost:4200/auth-callback" },
          PostLogoutRedirectUris = { "http://localhost:4200/" },
          AllowedScopes = new List<string>
          {
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile
          },
        }
      };
    }
  }
}
