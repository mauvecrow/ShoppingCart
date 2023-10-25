namespace ShoppingCart.ShoppingCart;

public class ShoppingCart
{
    private readonly HashSet<ShoppingCartItem> _items = new();

    public int UserId { get; }

    public IEnumerable<ShoppingCartItem> Items => _items;

    public ShoppingCart(int userId) => UserId = userId;

    public void AddItems(IEnumerable<ShoppingCartItem> cartItems)
    {
        foreach (var item in cartItems)
        {
            _items.Add(item);
        }
    }

    public void RemoveItems(int[] productCatalogIds) =>
        _items.RemoveWhere(
            i => productCatalogIds.Contains(i.ProductCatalogId)
        );
}

public record ShoppingCartItem(int ProductCatalogId, string ProductName, string Description, Money price)
{
    public virtual bool Equals(ShoppingCartItem? obj) =>
        obj != null && ProductCatalogId.Equals(obj.ProductCatalogId);

    public override int GetHashCode() => ProductCatalogId.GetHashCode();
}

public record Money(string Currency, decimal Amount);