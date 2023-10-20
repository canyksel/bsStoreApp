﻿using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services;

public class AuthenticationManager : IAuthenticationService
{
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    private User? _user;

    public AuthenticationManager(ILoggerService logger,
        IMapper mapper,
        UserManager<User> userManager,
        IConfiguration configuration)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> CreateToken()
    {
        var signinCredentials = GetSigninCredential();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signinCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
    {
        var user = _mapper.Map<User>(userForRegistrationDto);

        var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);

        if (result.Succeeded) await _userManager.AddToRolesAsync(user, userForRegistrationDto.Roles);

        return result;
    }

    public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto)
    {
        _user = await _userManager.FindByNameAsync(userForAuthenticationDto.UserName);

        var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuthenticationDto.Password));
        if (!result)
        {
            _logger.LogWarning($"{nameof(ValidateUser)} : Authentication failed. Wrong username or password.");
        }
        return result;
    }
    private SigningCredentials GetSigninCredential()
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, _user.UserName)
        };

        var roles = await _userManager
            .GetRolesAsync(_user);

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");

        var tokenOptions = new JwtSecurityToken(issuer: jwtSettings["validIssuer"], audience: jwtSettings["validAudience"], claims: claims, expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])), signingCredentials: signinCredentials);

        return tokenOptions;
    }
}
