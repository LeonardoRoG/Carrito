using Mapster;
using Novit.Academia.Endpoints.DTO;
using Novit.Academia.Repository;

namespace Novit.Academia.Service;

public interface ICarritoService
{
    List<CarritoResponseDto> GetCarritos();
    CarritoResponseDto GetCarrito(int idCarrito);
    int CreateCarrito();
    void RemoveCarrito(int idCarrito);
    void AddProducto(int idCarrito, List<ItemCarritoProductoDto> productos);
    void RemoveProducto(int idCarrito, List<int> idProductos);
    void Checkout(int idCarrito);
}

public class CarritoService(ICarritoRepository carritoRepository) : ICarritoService
{
    public int CreateCarrito()
    {
        return carritoRepository.AddCarrito();
    }

    public void AddProducto(int idCarrito, List<ItemCarritoProductoDto> productos)
    {
        carritoRepository.AddProducto(idCarrito, productos);
    }

    public void Checkout(int idCarrito)
    {
        carritoRepository.Checkout(idCarrito);
    }

    public CarritoResponseDto GetCarrito(int idCarrito)
    {
        return carritoRepository.GetCarrito(idCarrito).Adapt<CarritoResponseDto>();
    }

    public List<CarritoResponseDto> GetCarritos()
    {
        return carritoRepository.GetCarritos().Adapt<List<CarritoResponseDto>>();
    }

    public void RemoveCarrito(int idCarrito)
    {
        carritoRepository.RemoveCarrito(idCarrito);
    }

    public void RemoveProducto(int idCarrito, List<int> idProductos)
    {
        carritoRepository.RemoveProducto(idCarrito, idProductos);
    }
}
