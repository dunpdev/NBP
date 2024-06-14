﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NBP2024.Application.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NBP2024.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizationController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthorizationController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(CredentialModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = model.UserName,
                    Email = "username@gmail.com"
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    return Ok("User added");
                return BadRequest(result.Errors.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] CredentialModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user == null)
                return NotFound();



            if (await userManager.CheckPasswordAsync(user, model.Password))
            {
                // Generate JWT token
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("78fUjkyzfLz56gTq78fUjkyzfLz56gTq"));
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(2),
                    claims: authClaims,
                        audience: "https://localhost:5001/",
                        issuer: "https://localhost:5001/",
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                    );

                var tokenKey = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(
                    new
                    {
                        token = tokenKey,
                        expiration = token.ValidTo
                    });
            }
            return Unauthorized("Wrong username or password");
        }
    }
}
