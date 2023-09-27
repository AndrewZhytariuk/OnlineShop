using IdentityModel.Client;
using Microsoft.Extensions.Options;
using OnlineShop.Lib.Clients.IdentityServer;
using OnlineShop.Lib.Clients.UserManagementServer;
using OnlineShop.Lib.Options;
using OnlineShop.Lib.Requests;
using OnlineShop.Lib.Common.Models;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Lib.Serveces.UserManagementService.Models;

namespace OnlineShop.ConsoleAppTestApp
{
    public class AuthenticationServeceTest
    {
        private readonly IdentityServerApiOptions _identityServerApiOptions;

        private readonly IIdentityServerClient _identityServerClient;
        private readonly RolesClient _rolesClient;
        private readonly UsersClient _usersClient;

        public AuthenticationServeceTest (
            IOptions<IdentityServerApiOptions> options,
            IIdentityServerClient identityServerClient,
            RolesClient rolesClient,
            UsersClient usersClient
            )
        { 
            _identityServerApiOptions = options.Value;
            _identityServerClient = identityServerClient ?? throw new ArgumentNullException(nameof(identityServerClient));
            _rolesClient = rolesClient ?? throw new ArgumentNullException(nameof(rolesClient));
            _usersClient = usersClient ?? throw new ArgumentNullException(nameof(usersClient));
        }

        public async Task<string> RunUsersClientTest(string[] args)
        {
            var token = await _identityServerClient.GetApiToken(_identityServerApiOptions);
            _usersClient.HttpClient.SetBearerToken(token.AccessToken);

            var userName = "xyz7";
            var roleName = "ShopClient";
            var roleNames = new[] { "ShopClient", "ShopClient3" };

            var addResult = await _usersClient.Add(new CreateUserRequest() { User = new ApplicationUser() { UserName = userName }, Password = "Password_1" });
            Console.WriteLine($"ADD: {addResult.Succeeded}");

            Thread.Sleep(100);

            var changePasswordRequest = await _usersClient.ChangePassword(new UserPasswordChangeRequest() { UserName = userName, CurrentPassword = "Password_1", NewPassword = "Password_2" });
            Console.WriteLine($"CHANGE PASSWORD: {changePasswordRequest.Succeeded}");

            Thread.Sleep(100);

            var getOneRequest = await _usersClient.Get(userName);
            Console.WriteLine($"GET ONE: {getOneRequest.Code}");

            Thread.Sleep(100);

            var userToUpdate = getOneRequest.Payload;
            userToUpdate.DefaultAddress = new Address()
            {
                City = "Warsaw",
                Country = "Poland",
                PostalCode = "00-001",
                AddressLine1 = "Jasna 21",
                AddressLine2 = "34"
            };
            var updateResult = await _usersClient.Update(userToUpdate);
            Console.WriteLine($"UPDATE: {updateResult.Succeeded}");

            Thread.Sleep(100);

            var addToRoleRequest = await _usersClient.AddRole(new AddRemoveRoleRequest() { UserName = userName, RoleName = roleName });
            Console.WriteLine($"ADD TO ROLE: {addToRoleRequest.Succeeded}");

            Thread.Sleep(100);

            var removeFromRoleRequest = await _usersClient.RemoveFromRole(new AddRemoveRoleRequest() { UserName = userName, RoleName = roleName });
            Console.WriteLine($"REMOVE FROM ROLE: {removeFromRoleRequest.Succeeded}");

            Thread.Sleep(100);

            var addToRolesRequest = await _usersClient.AddToRoles(new AddRemoveRolesRequest() { UserName = userName, RoleNames = roleNames });
            Console.WriteLine($"ADD TO MANY ROLES: {addToRolesRequest.Succeeded}");

            Thread.Sleep(100);

            var removeFromRolesRequest = await _usersClient.RemoveFromRoles(new AddRemoveRolesRequest() { UserName = userName, RoleNames = roleNames });
            Console.WriteLine($"REMOVE FROM MANY ROLES: {removeFromRolesRequest.Succeeded}");

            getOneRequest = await _usersClient.Get(userName);
            Console.WriteLine($"GET ONE: {getOneRequest.Code}");

            Thread.Sleep(100);

            var deleteResult = await _usersClient.Remove(getOneRequest.Payload);
            Console.WriteLine($"DELETE: {deleteResult.Succeeded}");

            Thread.Sleep(100);

            var getAllRequest = await _usersClient.GetAll();
            Console.WriteLine($"GET ALL: {getOneRequest.Code}");

            Thread.Sleep(100);

            return "OK";
        }

        public async Task<string> RunRolesClientTests(string[] args)
        {
            var token = await _identityServerClient.GetApiToken(_identityServerApiOptions);
            _rolesClient.HttpClient.SetBearerToken(token.AccessToken);

            var roleName = "xyz7";

            var addResult = await _rolesClient.Add(new IdentityRole(roleName));
            Console.WriteLine($"ADD: {addResult.Succeeded}");

            Thread.Sleep(100);

            var getOneRequest = await _rolesClient.Get(roleName);
            Console.WriteLine($"GET ONE: {getOneRequest.Code}");

            Thread.Sleep(100);

            var userToUpdate = getOneRequest.Payload;
            var updateResult = await _rolesClient.Update(userToUpdate);
            Console.WriteLine($"UPDATE: {updateResult.Succeeded}");

            Thread.Sleep(100);

            getOneRequest = await _rolesClient.Get(roleName);
            Console.WriteLine($"GET ONE: {getOneRequest.Code}");

            Thread.Sleep(100);

            var deleteResult = await _rolesClient.Remove(getOneRequest.Payload);
            Console.WriteLine($"DELETE: {deleteResult.Succeeded}");

            Thread.Sleep(100);

            var getAllRequest = await _rolesClient.GetAll();
            Console.WriteLine($"GET ALL: {getOneRequest.Code}");

            Thread.Sleep(100);

            return "OK";
        }
    }
}
