using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace LMSEntity.Models
{
    public partial class LMS_SWDContext : DbContext
    {
        public static LMS_SWDContext Ins = new LMS_SWDContext();
        public LMS_SWDContext()
        {
            if (Ins == null) Ins = this;
        }

        public LMS_SWDContext(DbContextOptions<LMS_SWDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookCopy> BookCopies { get; set; } = null!;
        public virtual DbSet<BorrowInformation> BorrowInformations { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ImportBill> ImportBills { get; set; } = null!;
        public virtual DbSet<ImportBillBook> ImportBillBooks { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Wishlist> Wishlists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            if (!optionsBuilder.IsConfigured) { optionsBuilder.UseSqlServer(config.GetConnectionString("MyDBConStr")); }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.HasKey(e => e.Bid)
                    .HasName("PK__Blog__C6DE0CC11B34F4E6");

                entity.ToTable("Blog");

                entity.Property(e => e.Bid)
                    .HasMaxLength(20)
                    .HasColumnName("BId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.StaffId).HasMaxLength(20);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Blog__StaffId__5070F446");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.BookId).HasMaxLength(20);

                entity.Property(e => e.Author).HasMaxLength(50);

                entity.Property(e => e.Bname)
                    .HasMaxLength(50)
                    .HasColumnName("BName");

                entity.Property(e => e.Cid)
                    .HasMaxLength(20)
                    .HasColumnName("CId");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Quantity).HasMaxLength(200);

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Book__CId__3E52440B");
            });

            modelBuilder.Entity<BookCopy>(entity =>
            {
                entity.ToTable("BookCopy");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Bid)
                    .HasMaxLength(20)
                    .HasColumnName("BId");

                entity.Property(e => e.Condition).HasMaxLength(20);

                entity.HasOne(d => d.BidNavigation)
                    .WithMany(p => p.BookCopies)
                    .HasForeignKey(d => d.Bid)
                    .HasConstraintName("FK__BookCopy__BId__571DF1D5");
            });

            modelBuilder.Entity<BorrowInformation>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("PK__BorrowIn__CB394B190EC61927");

                entity.ToTable("BorrowInformation");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .HasColumnName("OId");

                entity.Property(e => e.BorrowDate).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.Rid)
                    .HasMaxLength(20)
                    .HasColumnName("RId");

                entity.Property(e => e.StaffId).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.BorrowInformations)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BorrowInf__Staff__5441852A");

                entity.HasMany(d => d.Bcps)
                    .WithMany(p => p.Brs)
                    .UsingEntity<Dictionary<string, object>>(
                        "BorrowDetail",
                        l => l.HasOne<BookCopy>().WithMany().HasForeignKey("BcpId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__BorrowDet__BcpId__5AEE82B9"),
                        r => r.HasOne<BorrowInformation>().WithMany().HasForeignKey("BrId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__BorrowDeta__BrId__59FA5E80"),
                        j =>
                        {
                            j.HasKey("BrId", "BcpId").HasName("PK__BorrowDe__34BB6F05C6D6F2AA");

                            j.ToTable("BorrowDetail");

                            j.IndexerProperty<string>("BrId").HasMaxLength(20);

                            j.IndexerProperty<string>("BcpId").HasMaxLength(255).IsUnicode(false);
                        });
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.Cname)
                    .HasMaxLength(50)
                    .HasColumnName("CName");
            });

            modelBuilder.Entity<ImportBill>(entity =>
            {
                entity.ToTable("ImportBill");

                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Sid)
                    .HasMaxLength(20)
                    .HasColumnName("SId");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.ImportBills)
                    .HasForeignKey(d => d.Sid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ImportBill__SId__4316F928");
            });

            modelBuilder.Entity<ImportBillBook>(entity =>
            {
                entity.HasKey(e => new { e.ImId, e.Bid })
                    .HasName("PK__ImportBi__4A9C3E90A30D12EA");

                entity.ToTable("ImportBillBook");

                entity.Property(e => e.ImId).HasMaxLength(20);

                entity.Property(e => e.Bid)
                    .HasMaxLength(20)
                    .HasColumnName("BId");

                entity.HasOne(d => d.BidNavigation)
                    .WithMany(p => p.ImportBillBooks)
                    .HasForeignKey(d => d.Bid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ImportBillB__BId__46E78A0C");

                entity.HasOne(d => d.Im)
                    .WithMany(p => p.ImportBillBooks)
                    .HasForeignKey(d => d.ImId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ImportBill__ImId__45F365D3");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PK__Supplier__CA195950F7777254");

                entity.ToTable("Supplier");

                entity.Property(e => e.Sid)
                    .HasMaxLength(20)
                    .HasColumnName("SId");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(15);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__User__C5B196623599DD93");

                entity.ToTable("User");

                entity.Property(e => e.Uid)
                    .HasMaxLength(20)
                    .HasColumnName("UId");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.Rid)
                    .HasMaxLength(20)
                    .HasColumnName("RId");

                entity.HasOne(d => d.RidNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Rid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__RId__3B75D760");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.ToTable("Wishlist");

                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Uid)
                    .HasMaxLength(20)
                    .HasColumnName("UId");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wishlist__UId__49C3F6B7");

                entity.HasMany(d => d.Bids)
                    .WithMany(p => p.Wids)
                    .UsingEntity<Dictionary<string, object>>(
                        "WishlistItem",
                        l => l.HasOne<Book>().WithMany().HasForeignKey("Bid").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__WishlistIte__BId__4D94879B"),
                        r => r.HasOne<Wishlist>().WithMany().HasForeignKey("Wid").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__WishlistIte__WId__4CA06362"),
                        j =>
                        {
                            j.HasKey("Wid", "Bid").HasName("PK__Wishlist__D75A85F5D6D16B3A");

                            j.ToTable("WishlistItem");

                            j.IndexerProperty<string>("Wid").HasMaxLength(20).HasColumnName("WId");

                            j.IndexerProperty<string>("Bid").HasMaxLength(20).HasColumnName("BId");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
