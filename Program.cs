using TestAngular_BE.Models;
using Microsoft.EntityFrameworkCore;
using TestAngular_BE.Services.IModelos;
using TestAngular_BE.Services.Implementacion;

using AutoMapper;
using TestAngular_BE.DTOs;
using TestAngular_BE.Utilities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AnalystsDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

//Injeccion - Listas
builder.Services.AddScoped<ICustomerTypeJc, CustomerTypeImp> ();
builder.Services.AddScoped<IServiceTypeJc, ServiceTypeImp> ();
builder.Services.AddScoped<IPetTypeJc, PetTypeImp> ();

//Injeccion - Interfaces y modelos
builder.Services.AddScoped<ICustomerJc, CustomerImp>();
builder.Services.AddScoped<IEmployeeJc, EmployeeImp>();
builder.Services.AddScoped<IPetJc, PetImp>();
builder.Services.AddScoped<IServiceJc, ServiceImp>();

//Injection - Automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Peticiones 
#region GET - Mostrar Lista de Clientes
app.MapGet("/Customers/Lista", async (
    ICustomerJc _customer,
    IMapper _mapper
    ) =>
{
    var listaCustomers = await _customer.GetList();
    var listaCustomersDTO = _mapper.Map<List<CustomerDTO>>(listaCustomers);

    if (listaCustomersDTO.Count > 0)
    {
        return Results.Ok(listaCustomersDTO);
    }
    else
    {
        return Results.NotFound();
    }

});
#endregion

#region GET - Mostrar Lista de Mascotas
app.MapGet("/Mascotas/Lista", async (
    IPetJc _pet,
    IMapper _mapper
    ) =>
{
    var listaPets = await _pet.GetList();
    var listaPetsDTO = _mapper.Map<List<PetDTO>>(listaPets);

    if (listaPetsDTO.Count > 0)
    {
        return Results.Ok(listaPetsDTO);
    }
    else
    {
        return Results.NotFound();
    }

});
#endregion

#region  GET - Mostrar Lista de Empleados
app.MapGet("/Empleados/Lista", async (
    IEmployeeJc _Employee,
    IMapper _mapper
    ) =>
{
    var listaEmployee = await _Employee.GetList();
    var listaEmployeeDTO = _mapper.Map<List<EmployeeDTO>>(listaEmployee);

    if (listaEmployeeDTO.Count > 0)
    {
        return Results.Ok(listaEmployeeDTO);
    }
    else
    {
        return Results.NotFound();
    }

});
#endregion

#region GET - Mostrar Lista de Servicios
app.MapGet("/Servicios/Lista", async (
    IServiceJc _Services,
    IMapper _mapper
    ) =>
{
    var listaService = await _Services.GetList();
    var listaServiceDTO = _mapper.Map<List<ServiceDTO>>(listaService);

    if (listaServiceDTO.Count > 0)
    {
        return Results.Ok(listaServiceDTO);
    }
    else
    {
        return Results.NotFound();
    }

});
#endregion

#region GET - Mostrar Lista de Tipos de Servicios
app.MapGet("/TipoDeServicios/Lista", async (
    IServiceTypeJc _ServiceType,
    IMapper _mapper
    ) =>
{
    var listaServiceType = await _ServiceType.GetList();
    var listaServiceTypeDTO = _mapper.Map<List<ServiceTypeDTO>>(listaServiceType);

    if (listaServiceTypeDTO.Count > 0)
    {
        return Results.Ok(listaServiceTypeDTO);
    }
    else
    {
        return Results.NotFound();
    }

});
#endregion

#region GET - Mostrar Lista de Tipos de Mascota
app.MapGet("/TipoDeMascota/Lista", async (
    IPetTypeJc _PetType,
    IMapper _mapper
    ) =>
{
    var listaPetType = await _PetType.GetList();
    var listaPetTypeDTO = _mapper.Map<List<PettypeDTO>>(listaPetType);

    if (listaPetTypeDTO.Count > 0)
    {
        return Results.Ok(listaPetTypeDTO);
    }
    else
    {
        return Results.NotFound();
    }

});
#endregion

#region GET - Mostrar Lista de Tipos de Mascota
app.MapGet("/TipoDeCustomer/Lista", async (
    ICustomerTypeJc _CustomerType,
    IMapper _mapper
    ) =>
{
    var listaCustomerType = await _CustomerType.GetList();
    var listaCustomerTypeDTO = _mapper.Map<List<CustomerTypeDTO>>(listaCustomerType);

    if (listaCustomerTypeDTO.Count > 0)
    {
        return Results.Ok(listaCustomerTypeDTO);
    }
    else
    {
        return Results.NotFound();
    }

});
#endregion

#region POST - Guardar un nuevo cliente
app.MapPost("/Customer/Guardar", async (
    CustomerDTO modelo,
    ICustomerJc _addCustomer,
    IMapper _mapper
    ) =>
{
    var _customer = _mapper.Map<CustomerJc>(modelo);
    var _newCustomer = await _addCustomer.Add(_customer);

    if(_newCustomer.Id != 0)
    {
        return Results.Ok(_mapper.Map<CustomerDTO>(_newCustomer));
    }
    else
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});
#endregion

app.UseCors("NewPolicy");
app.Run();

