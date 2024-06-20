using Identity.Configurations;
using Identity.DTOs.Requests;
using Identity.DTOs.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public IdentityService(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<CreateUserResponse> CreateUser(CreateUserRequest userCreate, bool isSupportUser = false)
        {
            var identityUser = new IdentityUser
            {
                UserName = userCreate.Email,
                Email = userCreate.Email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(identityUser, userCreate.Password);
            if (result.Succeeded)
                await _userManager.SetLockoutEnabledAsync(identityUser, false);

            if (isSupportUser)
                await _userManager.AddToRoleAsync(identityUser, "Support");

            var createUserResponse = new CreateUserResponse(result.Succeeded);

            if (!result.Succeeded && result.Errors.Any())
                createUserResponse.AddErrors(result.Errors.Select(x => x.Description));

            return createUserResponse;
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);
            if (result.Succeeded)
                return await GenerateToken(userLogin.Email);

            var userLoginResponse = new UserLoginResponse(result.Succeeded);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    userLoginResponse.AddError("Essa conta está bloqueada");
                else if (result.IsNotAllowed)
                    userLoginResponse.AddError("Essa conta não tem permissão para fazer login");
                else if (result.RequiresTwoFactor)
                    userLoginResponse.AddError("É necessário confirmar o login no seu segundo dispositivo");
                else
                    userLoginResponse.AddError("Usuário e/ou senha estão incorretos");
            }

            return userLoginResponse;
        }

        public async Task<bool> DeleteUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                return result.Succeeded;
            }

            return true;
        }

        private async Task<UserLoginResponse> GenerateToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var tokenClaims = await GetClaims(user);

            var expirationDate = DateTime.UtcNow.AddSeconds(_jwtOptions.Expiration);

            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: tokenClaims,
                notBefore: DateTime.UtcNow,
                expires: expirationDate,
                signingCredentials: _jwtOptions.SigningCredentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new UserLoginResponse(
                success: true,
                token: token,
                expirationDate: expirationDate
                );
        }

        private async Task<IList<Claim>> GetClaims(IdentityUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.UtcNow.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()));

            foreach (var role in roles)
                claims.Add(new Claim("role", role));

            return claims;
        }
    }
}