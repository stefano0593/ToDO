using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Todo.Application.Settings;
using Todo.Domain.Accounts.Models;

namespace Todo.Application.Helpers;

public class JwtHelper
{
    private readonly JwtSecurityTokenHandler _tokenHandler;
    private readonly JwtSettings _jwtSettings;

    public JwtHelper(JwtSettings jwtSettings)
    {
        _tokenHandler = new JwtSecurityTokenHandler();
        _jwtSettings = jwtSettings;
    }

    public string GenerateAuthenticationToken(IdentityUser existingIdentity, Account account)
    {
        var claims = CreateClaims(existingIdentity, account);
        var signingKey = CreateSigninKey();
        var tokenDescriptor = CreateTokenDescriptor(claims, signingKey); 
        
        return CreateToken(tokenDescriptor);
    }

    private IReadOnlyList<Claim> CreateClaims(IdentityUser existingIdentity, Account account)
    {
        return new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, existingIdentity.Email),
            new Claim(JwtRegisteredClaimNames.Email, existingIdentity.Email),
            new Claim(JwtRegisteredClaimNames.GivenName, account.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, account.LastName),
            new Claim(JwtRegisteredClaimNames.NameId, existingIdentity.Id),
            new Claim("accountIdentifier", account.AccountId.Value.ToString()),
        };
    }

    private byte[] CreateSigninKey()
    {
        return Encoding.ASCII.GetBytes(_jwtSettings.SigningKey);
    }

    private SecurityTokenDescriptor CreateTokenDescriptor(IReadOnlyList<Claim> claims, byte[] signingKey)
    {
        return new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey),
                SecurityAlgorithms.HmacSha256Signature)
        };
    }

    private string CreateToken(SecurityTokenDescriptor descriptor)
    {
        var tokenCreate = _tokenHandler.CreateToken(descriptor);
        var token = _tokenHandler.WriteToken(tokenCreate);
        return token;
    }
}