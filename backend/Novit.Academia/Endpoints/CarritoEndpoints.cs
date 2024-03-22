using Carter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Novit.Academia.Database;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;
using Novit.Academia.Service;

namespace Novit.Academia.Endpoints;

public class CarritoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Carrito");

        app.MapGet("/", (ICarritoService carritoService) =>
        {
            var carritosDto = carritoService.GetCarritos();
            return Results.Ok(carritosDto);

        })
            .WithTags("Carrito")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "cliente, vendedor, administrador" });

        app.MapGet("/{idCarrito:int}", (ICarritoService carritoService, int idCarrito) => 
        {
            var carritoDto = carritoService.GetCarrito(idCarrito);
            return Results.Ok(carritoDto);

        })
            .WithTags("Carrito")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "cliente, vendedor, administrador" });

        app.MapPost("/", (ICarritoService carritoService) => 
        {
            int idCarrito = carritoService.CreateCarrito();
            return Results.Ok(idCarrito);

        })
            .WithTags("Carrito")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "cliente, administrador" });

        app.MapDelete("/{idCarrito:int}", (ICarritoService carritoService, int idCarrito) => 
        {
            carritoService.RemoveCarrito(idCarrito);
            return Results.Ok();

        })
            .WithTags("Carrito")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "cliente, administrador" });

        app.MapPost("/{idCarrito:int}/Producto", (ICarritoService carritoService, int idCarrito, [FromBody] List<ItemCarritoProductoDto> productos) =>
        {
            carritoService.AddProducto(idCarrito, productos);
            return Results.Ok();

        })
            .WithTags("Carrito")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "cliente, administrador" });

        app.MapDelete("/{idCarrito:int}/Producto", (ICarritoService carritoService, int idCarrito, [FromBody] List<int> idProductos) => 
        {
            carritoService.RemoveProducto(idCarrito, idProductos);
            return Results.Ok();

        })
            .WithTags("Carrito")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "cliente, administrador" });

        app.MapPost("/{idCarrito}/Checkout", (ICarritoService carritoService ,int idCarrito) => 
        {
            carritoService.Checkout(idCarrito);
            return Results.Ok();

        })
            .WithTags("Carrito")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "cliente, administrador" });
    }
}
