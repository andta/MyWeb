
namespace MyWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Data.Entity.Infrastructure;

    //步骤（2）  创建数据库上下文DbContext
    public class ModelContext : DbContext
    {
        public ModelContext() : base("name=MyModelContext") { }
        static ModelContext()
        {
            //Entity Framework数据库初始化五种种策略
            //策略一：数据库不存在时重新创建数据库，存在则不创建
            //Database.SetInitializer<ModelContext>(new CreateDatabaseIfNotExists<ModelContext>());
            //策略二：每次启动应用程序时创建数据库
            //Database.SetInitializer<ModelContext>(new DropCreateDatabaseAlways<ModelContext>());
            //策略三：模型更改时重新创建数据库
            //Database.SetInitializer<ModelContext>(new DropCreateDatabaseIfModelChanges<ModelContext>());
            //策略四：从不创建数据库
            Database.SetInitializer<ModelContext>(null);
            //策略五：创建初始化数据
            //Database.SetInitializer<ModelContext>(new CompanyInitializer());
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。
        public virtual DbSet<MyEntity> DbSet_MyEntitie { get; set; }
        public virtual DbSet<WenZhang> DbSet_WenZhang { get; set; }
        public virtual DbSet<YongHu> DbSet_YongHu { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //数据库表名非复数（不带S）
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            //将实体类型映射到数据库中的特定表
            //modelBuilder.Entity<WenZhang>().ToTable("t_WenZhang");
        }

    }

    //创建初始化数据
    public class CompanyInitializer : System.Data.Entity.CreateDatabaseIfNotExists<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {
            var students = new List<YongHu>
            {
                new YongHu{YongHuMing="李斌"},
                new YongHu{YongHuMing="张三"}
            };
            students.ForEach(s => context.DbSet_YongHu.Add(s));
            context.SaveChanges();
        }
    }

}