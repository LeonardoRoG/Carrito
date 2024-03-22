using Microsoft.EntityFrameworkCore;
using Novit.Academia.Database;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia.Repository;

public interface IProductoRepository
{
    List<Producto> GetProductos();
    Producto GetProducto(int idProducto);
    void AddProducto(ProductoDto productoDto);
    int UpdateProducto(int idProducto, ProductoDto productoDto);
    void RemoveProducto(int idProducto);
}

public class ProductoRepository(AppDbContext context) : IProductoRepository
{
    public void AddProducto(ProductoDto productoDto)
    {
        Producto producto = new()
        {
            Nombre = productoDto.Nombre,
            Descripcion = productoDto.Descripcion,
            Precio = productoDto.Precio,
            Stock = productoDto.Stock,
            UrlImagen = productoDto.UrlImagen,
        };

        context.Productos.Add(producto);
        context.SaveChanges();
    }

    public Producto GetProducto(int idProducto)
    {
        var producto = context.Productos.SingleOrDefault(p => p.IdProducto == idProducto);
        return producto;
    }

    public List<Producto> GetProductos()
    {
        var productos = context.Productos.ToList();
        return productos;
    }

    public void RemoveProducto(int idProducto)
    {
        var producto = context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);

        if (producto == null)
            throw new Exception($"El producto con id {idProducto} no existe.");

        context.Productos.Remove(producto);
        context.SaveChanges();
    }

    public int UpdateProducto(int idProducto, ProductoDto productoDto)
    {
        var rowsAffected = context.Productos.Where(x => x.IdProducto == idProducto)
            .ExecuteUpdate(update =>
                update.SetProperty(entity => entity.Nombre, productoDto.Nombre)
                      .SetProperty(entity => entity.Descripcion, productoDto.Descripcion)
                      .SetProperty(entity => entity.Precio, productoDto.Precio)
                      .SetProperty(entity => entity.Stock, productoDto.Stock)
                      .SetProperty(entity => entity.UrlImagen, productoDto.UrlImagen));

        return rowsAffected;
    }
}