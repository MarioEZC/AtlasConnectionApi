using AtlasConnectionApiCode.DataAccess;
using AtlasConnectionApiCode.Mapper;
using AtlasConnectionApiCode.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSetting>(builder.Configuration.GetSection("MongoDbSettings"));

// Add services to the container.
builder.Services.AddSingleton<UserDataAccess>();
builder.Services.AddSingleton<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(AutoMapperUserModelProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
