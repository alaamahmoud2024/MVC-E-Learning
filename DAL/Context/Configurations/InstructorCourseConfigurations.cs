using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    public class InstructorCourseConfigurations : IEntityTypeConfiguration<InstructorCourse>
    {
        public void Configure(EntityTypeBuilder<InstructorCourse> builder)
        {
            builder.HasOne(sc => sc.Instructor)
                .WithMany(s => s.InstructorCourses)
                .HasForeignKey(sc => sc.InstructorId);

            builder.HasOne(sc => sc.Course)
                .WithMany(c => c.InstructorCourses)
                .HasForeignKey(sc => sc.CourseId);


        }
    }
}
