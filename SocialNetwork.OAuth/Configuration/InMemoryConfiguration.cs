using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using IdentityServer4.Models;
using IdentityServer4.Test;

namespace SocialNetwork.OAuth.Configuration
{
    public class InMemoryConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[] { new ApiResource("socialnetwork", "Social Network") };
        }

        public static IEnumerable<Client> Clients()
        {
            return new[] { new Client
                               {
                                   ClientId = "socialnetwork",
                                   ClientSecrets = new []
                                                       {
                                                            new Secret("secret".Sha256()),
                                                       },
                                   AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                                   AllowedScopes = new []{ "socialnetwork" }
                               } 
                             };
        }

        public static IEnumerable<TestUser> Users()
        {
            return new[] {
                new TestUser
                               {
                                   SubjectId = "1",
                                   Username = "igary",
                                   Password = "password"
                               } 
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
    }
}
