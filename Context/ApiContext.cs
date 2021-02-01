using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace webapi.Models
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<VendaItem> VendaItem { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.ToTable("venda");

                entity.HasIndex(e => e.IdVendedor)
                    .HasName("fk_venda_vendedor_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_cadastro")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.IdVendedor)
                    .HasColumnName("id_vendedor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venda_vendedor");
            });

            modelBuilder.Entity<VendaItem>(entity =>
            {
                entity.ToTable("venda_item");

                entity.HasIndex(e => e.IdProduto)
                    .HasName("fk_venda_item_produto1_idx");

                entity.HasIndex(e => e.IdVenda)
                    .HasName("fk_venda_item_venda1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProduto)
                    .HasColumnName("id_produto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVenda)
                    .HasColumnName("id_venda")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantidade)
                    .HasColumnName("quantidade")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.VendaItem)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venda_item_produto1");

                entity.HasOne(d => d.IdVendaNavigation)
                    .WithMany(p => p.VendaItens)
                    .HasForeignKey(d => d.IdVenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venda_item_venda1");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.ToTable("vendedor");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasColumnType("varchar(14)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
