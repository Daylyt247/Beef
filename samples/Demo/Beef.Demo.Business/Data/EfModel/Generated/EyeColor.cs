/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable

using System;
using Microsoft.EntityFrameworkCore;

namespace Beef.Demo.Business.Data.EfModel
{
    /// <summary>
    /// Represents the Entity Framework (EF) model for database object 'Ref.EyeColor'.
    /// </summary>
    public class EyeColor
    {
        /// <summary>
        /// Gets or sets the 'EyeColorId' column value.
        /// </summary>
        public Guid EyeColorId { get; set; }

        /// <summary>
        /// Gets or sets the 'Code' column value.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets the 'Text' column value.
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Gets or sets the 'IsActive' column value.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets the 'SortOrder' column value.
        /// </summary>
        public int? SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the 'RowVersion' column value.
        /// </summary>
        public byte[]? RowVersion { get; set; }

        /// <summary>
        /// Gets or sets the 'CreatedBy' column value.
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the 'CreatedDate' column value.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the 'UpdatedBy' column value.
        /// </summary>
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the 'UpdatedDate' column value.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Adds the table/model configuration to the <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/>.</param>
        public static void AddToModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EyeColor>(entity =>
            {
                entity.ToTable("EyeColor", "Ref");
                entity.HasKey("EyeColorId");
                entity.Property(p => p.EyeColorId).HasColumnType("UNIQUEIDENTIFIER");
                entity.Property(p => p.Code).HasColumnType("NVARCHAR(50)");
                entity.Property(p => p.Text).HasColumnType("NVARCHAR(250)");
                entity.Property(p => p.IsActive).HasColumnType("BIT");
                entity.Property(p => p.SortOrder).HasColumnType("INT");
                entity.Property(p => p.RowVersion).HasColumnType("TIMESTAMP").IsRowVersion();
                entity.Property(p => p.CreatedBy).HasColumnType("NVARCHAR(250)").ValueGeneratedOnUpdate();
                entity.Property(p => p.CreatedDate).HasColumnType("DATETIME2").ValueGeneratedOnUpdate();
                entity.Property(p => p.UpdatedBy).HasColumnType("NVARCHAR(250)").ValueGeneratedOnAdd();
                entity.Property(p => p.UpdatedDate).HasColumnType("DATETIME2").ValueGeneratedOnAdd();
            });
        }
    }
}

#nullable restore