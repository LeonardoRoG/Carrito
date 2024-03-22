using Carter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Novit.Academia.Endpoints.DTO;
using Novit.Academia.Service;

namespace Novit.Academia.Endpoints;

public class ProductoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Producto");

        // GET - Obtener lista de productos
        app.MapGet("/", (IProductoService productoService) =>
        {
            var productos = productoService.GetProductos();
            return Results.Ok(productos);

        })
            .WithTags("Producto")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "cliente, vendedor, administrador" });

        // GET - Obtener un producto según su id
        app.MapGet("/{idProducto:int}", (IProductoService productoService, int idProducto) =>
        {
            var producto = productoService.GetProducto(idProducto);
            return Results.Ok(producto);

        })
            .WithTags("Producto")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "cliente, vendedor, administrador" });

        // POST - Crear un producto nuevo
        app.MapPost("/", ([FromServices] IProductoService productoService, [FromBody] ProductoRequestDto productoDto) =>
        {
            productoService.CreateProducto(productoDto);
            return Results.Created();

        })
            .WithTags("Producto")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "vendedor, administrador" });

        // PUT - Modificar un producto
        app.MapPut("/{idProducto}", ([FromServices] IProductoService productoService, int idProducto, [FromBody] ProductoRequestDto productoDto) =>
        {
            productoService.UpdateProducto(idProducto, productoDto);
            return Results.Ok();

        })
            .WithTags("Producto")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "vendedor, administrador" });

        // DELETE - Eliminar un producto
        app.MapDelete("/{idProducto}", (IProductoService productoService, int idProducto) =>
        {
            productoService.DeleteProducto(idProducto);
            return Results.NoContent();

        })
            .WithTags("Producto")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "vendedor, administrador" });
    }
}
