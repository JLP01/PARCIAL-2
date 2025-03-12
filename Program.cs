using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaCajaUnapec.Data;
using SistemaCajaUnapec.Models;
using System;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Configurar Entity Framework e Identity
builder.Services.AddDbContext<CajaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CajaContext")));

builder.Services.AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<CajaContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el pipeline de middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Crear el usuario administrador si no existe
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<Usuario>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    string adminEmail = "admin@unapec.edu.do";
    string adminPassword = "Admin123*";

    // Verificar si el rol "Admin" existe, si no, crearlo
    try
    {
        // Verificar si el rol "Admin" existe, si no, crearlo
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            var result = await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (result.Succeeded)
            {
                // If creation is successful
                Console.WriteLine("Rol 'Admin' creado exitosamente.");
            }
            else
            {
                // If creation fails, log or handle the failure
                Console.WriteLine("Error al crear el rol 'Admin': " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
        else
        {
            Console.WriteLine("El rol 'Admin' ya existe.");
        }
    }
    catch (Exception ex)
    {
        // Catch any unexpected exceptions
        Console.WriteLine("Ocurrió un error al verificar o crear el rol 'Admin': " + ex.Message);
    }

    // Verificar si el usuario administrador ya existe
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var user = new Usuario
        {
            UserName = adminEmail,
            Email = adminEmail,
            Nombre = "Administrador",
            Apellido = "Principal",
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}

// Establecer la página de inicio en Account/Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
