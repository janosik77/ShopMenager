using Microsoft.EntityFrameworkCore;


namespace RestApiShopmenager.Models.Contexts;

public partial class CompanyContext : DbContext
{
    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categories> Categories { get; set; }

    public virtual DbSet<Customers> Customers { get; set; }

    public virtual DbSet<Discounts> Discounts { get; set; }

    public virtual DbSet<Employees> Employees { get; set; }

    public virtual DbSet<OrderDetails> OrderDetails { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<PaymentMethods> PaymentMethods { get; set; }

    public virtual DbSet<PaymentStatuses> PaymentStatuses { get; set; }

    public virtual DbSet<Payments> Payments { get; set; }

    public virtual DbSet<Products> Products { get; set; }

    public virtual DbSet<Reviews> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categories>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B71E3FB79");
        });

        modelBuilder.Entity<Customers>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B89D716B3B");
        });

        modelBuilder.Entity<Discounts>(entity =>
        {
            entity.HasKey(e => e.DiscountId).HasName("PK__Discount__E43F6DF657A3095B");
        });

        modelBuilder.Entity<Employees>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1DB3C1AC3");

            entity.Property(e => e.PasswordHash).HasDefaultValue("");
        });

        modelBuilder.Entity<OrderDetails>(entity =>
        {
            entity.HasOne(d => d.Discount).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_OrderDetails_Discounts");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails).HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails).HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<Orders>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF920470A5");

            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue("Pending");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders).HasConstraintName("FK_Orders_Employees");
        });

        modelBuilder.Entity<PaymentMethods>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PK__PaymentM__DC31C1F38DE62B97");
        });

        modelBuilder.Entity<PaymentStatuses>(entity =>
        {
            entity.HasKey(e => e.PaymentStatusId).HasName("PK__PaymentS__34F8AC1F1D89707C");
        });

        modelBuilder.Entity<Payments>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58F6C5182E");

            entity.Property(e => e.PaymentDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments).HasConstraintName("FK_Payments_Orders");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_PaymentMethods");

            entity.HasOne(d => d.PaymentStatus).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_PaymentStatuses");
        });

        modelBuilder.Entity<Products>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED2DE016E6");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK_Products_Categories");
        });

        modelBuilder.Entity<Reviews>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AE4F97CFAD");

            entity.Property(e => e.ReviewDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Employee).WithMany(p => p.Reviews).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews).HasConstraintName("FK_Reviews_Products");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
