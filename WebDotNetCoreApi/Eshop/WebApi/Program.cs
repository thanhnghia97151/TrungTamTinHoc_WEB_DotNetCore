var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();//=> sử dụng cho wwwroot -> image, sử lý hình ảnh
app.MapControllers();
app.Run();
