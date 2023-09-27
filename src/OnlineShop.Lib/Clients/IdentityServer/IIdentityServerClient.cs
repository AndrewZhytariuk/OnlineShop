using OnlineShop.Lib.Options;
using OnlineShop.Lib.Serveces.IdentityServer;

namespace OnlineShop.Lib.Clients.IdentityServer;
public interface IIdentityServerClient
    {
    Task<Token> GetApiToken(IdentityServerApiOptions options);
    }

