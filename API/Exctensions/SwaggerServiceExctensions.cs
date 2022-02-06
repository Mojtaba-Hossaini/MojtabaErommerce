namespace API.Exctensions;

public static class SwaggerServiceExctensions
{
    public static WebApplicationBuilder AddSwaggerDocumention(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        return builder;
    }

    public static WebApplication UserSwaggerDocumention(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}
