using Telestream.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telestream.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        public virtual DbSet<ContactList> ContactLists { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<SMS> SMSes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            InitiateEntity(modelBuilder);
        }

        private void InitiateEntity(ModelBuilder modelBuilder)
        {
            #region Contact List
            modelBuilder.Entity<ContactList>(entity =>
            {
                entity.ToTable("contact_list");
                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.fileName)
                    .IsRequired()
                    .HasColumnName("file_name")
                    .HasMaxLength(255);
                entity.Property(e => e.displayName)
                    .IsRequired()
                    .HasColumnName("display_name")
                    .HasMaxLength(255);
                entity.Property(e => e.uploadedAt)
                    .HasColumnName("uploaded_at")
                    .HasColumnType("datetime");
            });
            #endregion Contact List
            
            #region Settings
            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("settings");
                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("int");
                entity.Property(e => e.value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(255);
            });
            #endregion Settings
            
            #region SMS
            modelBuilder.Entity<SMS>(entity =>
            {
                entity.ToTable("sms");

                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.contact)
                    .IsRequired()
                    .HasColumnName("contact")
                    .HasMaxLength(255);
                entity.Property(e => e.from)
                    .IsRequired()
                    .HasColumnName("from")
                    .HasMaxLength(255);
                entity.Property(e => e.to)
                    .IsRequired()
                    .HasColumnName("to")
                    .HasMaxLength(255);
                entity.Property(e => e.content)
                    .IsRequired()
                    .HasColumnName("content");
                entity.Property(e => e.read)
                    .HasColumnName("read")
                    .HasDefaultValue(false)
                    .HasColumnType("bit");
                entity.Property(e => e.sent)
                    .HasColumnName("sent")
                    .HasDefaultValue(false)
                    .HasColumnType("bit");
                entity.Property(e => e.messageId)
                    .HasColumnName("message_id")
                    .HasMaxLength(255);
                entity.Property(e => e.successed)
                    .HasColumnName("successed")
                    .HasDefaultValue(false)
                    .HasColumnType("bit");
                entity.Property(e => e.createdAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");
            });
            #endregion FCS
        }
    }
}
