using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context.Configurations
{
    public class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasOne(c => c.Topic)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TopicId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Assignments)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
