using System;

namespace Inventory.Service.Dtos
{
    public record GrantItemsDto(Guid UserId , Guid CatalogItemId , int Quantity);
    public record InventoryItemDto(Guid CatalogItemDto ,string Name, string Description ,int Quantity , DateTimeOffset AcquiredDate );
    public record CatalogItemDto(Guid id ,string Name ,string Description , decimal Price , DateTimeOffset CreatedDate);

}
