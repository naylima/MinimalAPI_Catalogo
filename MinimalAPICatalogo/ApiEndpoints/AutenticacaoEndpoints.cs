using System;
using Microsoft.AspNetCore.Authorization;
using MinimalAPICatalogo.Models;
using MinimalAPICatalogo.Services;

namespace MinimalAPICatalogo.ApiEndpoints;

public static class AutenticacaoEndpoints
{
	public static void MapAutenticacaoEndpoints(this WebApplication app)
	{
        app.MapPost("/login", [AllowAnonymous] (User user, ITokenService tokenService) =>
        {
            if (user == null)
            {
                return Results.BadRequest("Login Inválido.");
            }
            if (user.Username == "nayara" && user.Password == "numsey#123")
            {
                var tokenString = tokenService.GerarToken(app.Configuration["Jwt:Key"],
                        app.Configuration["Jwt:Issuer"],
                        app.Configuration["Jwt:Audience"],
                        user);
                return Results.Ok(new { token = tokenString });
            }
            else
            {
                return Results.BadRequest("Login Inválido.");
            }
        })
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status200OK)
        .WithName("Login")
        .WithTags("Autenticação");
    }
}

