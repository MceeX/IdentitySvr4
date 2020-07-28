using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerMcee.IdentitySvr
{
  public class Config
  {
    public static IEnumerable<ApiScope> GetApiScopes()
    {
      return new List<ApiScope>
      {
        new ApiScope("BankOMceeAPI",".Net app scope")
      };
    }
    
    public static IEnumerable<ApiResource> GetAllApiResources()
    {
      return new List<ApiResource>
      {
        new ApiResource("BankOMceeAPI","Customer API for BankOAPI")
      };
    }

    public static IEnumerable<Client> GetClients()
    {
      return new List<Client>
      {
        new Client
        {
          ClientId = "client",
          AllowedGrantTypes = GrantTypes.ClientCredentials,
          ClientSecrets =
          {
            new Secret("secret".Sha256())
          },
          AllowedScopes = { "BankOMceeAPI", "offline_access"},
        }
      };
    }
  }
}
