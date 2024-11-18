using SisLog.API;

var builder = WebApplication.CreateBuilder(args);
builder.AddAPI();

var app = builder.Build();

app.CheckDevModeConfig(builder.Environment);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.AddHealthCheckEndpoints();

await app.RunAsync();
