using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RoadMap.Domain.Security;

namespace RoadMap.Application.Security.Service;

public class JwtService: IJwtService
{
    
    
    private readonly JwtSetting _jwtOption;

    public JwtService(IOptions<JwtSetting> setting)
    {
        
        _jwtOption = setting.Value;
        
    }
    public string GetToken(string userName)
    {
        
        var claims = CreateClaim(userName);
        var signingCredentials = GetSigningCredentials(_jwtOption);
        var jwtToken = GetJwtToken(claims, signingCredentials);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;
    }
    
    
    private JwtSecurityToken GetJwtToken(List<Claim> claims, SigningCredentials SigningCredentials)
    {

        return new JwtSecurityToken(
            issuer: _jwtOption.Issuer,
            audience: _jwtOption.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtOption.DurationInMinute),
            signingCredentials: SigningCredentials
        );

    }
    
    
    
    private List<Claim> CreateClaim(string userName)
    {

        return new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,userName)

        };

        
    }
    
    private SigningCredentials GetSigningCredentials(JwtSetting jwtOption)
    {

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.Key));
        return new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);



    }
}