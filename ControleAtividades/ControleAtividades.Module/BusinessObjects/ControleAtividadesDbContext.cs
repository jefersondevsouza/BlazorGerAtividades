using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;

namespace ControleAtividades.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class ControleAtividadesContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var optionsBuilder = new DbContextOptionsBuilder<ControleAtividadesEFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new ControleAtividadesEFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class ControleAtividadesDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ControleAtividadesEFCoreDbContext> {
	public ControleAtividadesEFCoreDbContext CreateDbContext(string[] args) {
        //throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
        var optionsBuilder = new DbContextOptionsBuilder<ControleAtividadesEFCoreDbContext>();
        //optionsBuilder.UseSqlServer("Integrated Security=SSPI;Pooling=false;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=DXFin5");
        //optionsBuilder.UseSqlServer("Integrated Security=SSPI;Data Source=192.168.5.44;Initial Catalog=BlazorTeste;user=master;password=mst");
        optionsBuilder.UseSqlServer("Integrated Security=SSPI;Data Source=.\\SQLEXPRESS;Initial Catalog=ControleAtividades;user=master;password=mst");



        //optionsBuilder.UseChangeTrackingProxies();
        //optionsBuilder.UseObjectSpaceLinkProxies();
        return new ControleAtividadesEFCoreDbContext(optionsBuilder.Options);
    }
}
[TypesInfoInitializer(typeof(ControleAtividadesContextInitializer))]
public class ControleAtividadesEFCoreDbContext : DbContext {
	public ControleAtividadesEFCoreDbContext(DbContextOptions<ControleAtividadesEFCoreDbContext> options) : base(options) {
	}
	public DbSet<Versao> Versao { get; set; }
	public DbSet<Parametro> Parametro { get; set; }
	public DbSet<Cargo> Cargo { get; set; }
	public DbSet<Colaborador> Colaborador { get; set; }
    public DbSet<Atividade> Atividade { get; set; }
    
    public DbSet<Interrupcao> Interrupcao { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
    }
}
