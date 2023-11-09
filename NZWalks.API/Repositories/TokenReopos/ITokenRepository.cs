using System;
using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Repositories.TokenReopos
{
	public interface ITokenRepository
	{
        String CreateJWTToken(IdentityUser user, List<String> roles);
	}
}

