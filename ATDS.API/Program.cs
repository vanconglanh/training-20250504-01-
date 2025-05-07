using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json.Serialization;
using ATDS.Business.Interfaces;
using ATDS.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using ATDS.API.Helpers;
using NLog.Extensions.Logging;
using Optivem.Framework.Core.Domain;
using ATDS.API.Info;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

//builder.Services.AddControllersWithViews()
//                .AddJsonOptions(options =>
//                {
//                    // Global settings: use the defaults, but serialize enums as strings
//                    // (because it really should be the default)
//                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
//                });

//builder.Services.AddControllers(options =>
//{
//    options.RespectBrowserAcceptHeader = true;
//}).AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.PropertyNamingPolicy = null;
//});

//--- Json
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});

//--- Add for get httpContext
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//--- Jwt
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

//--- Email and SMS
//AddSingleton: Services ch? ???c t?o 1 l?n duy nh?t
//Scoped:  T?o m?t th? hi?n m?i cho t?t c? c?c scope (M?i request l? m?t scope). Trong scope th? service ???c d?ng l?i
//Transitent: M?t th? hi?n m?i lu?n ???c t?o, m?i khi ???c y?u c?u.
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection(nameof(EmailSettings)));
var smsSetting = builder.Configuration.GetSection(nameof(SmsSettings));
SmsSettings smsSettings = new SmsSettings();
smsSetting.Bind(smsSettings);
builder.Services.AddSingleton(smsSettings);
builder.Services.AddTransient<ISmsService, SmsService>();
builder.Services.AddTransient<IEmailService, EmailService>();

//--- Multilanguage
//builder.Services.Configure<MultilanguageSettings>(builder.Configuration.GetSection(nameof(MultilanguageSettings)));
// Add location services
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
// Configuring location options
//builder.Services.Configure<RequestLocalizationOptions>(options => {
//    var SupportedCultures = new[] { "vi-VN", "en-US", "ja-JP" };
//    options.SetDefaultCulture("vi-VN")
//            .AddSupportedCultures(SupportedCultures)
//            .AddSupportedUICultures(SupportedCultures)
//            .RequestCultureProviders = new List<IRequestCultureProvider>
//            {
//                new AcceptLanguageHeaderRequestCultureProvider(),
//                new QueryStringRequestCultureProvider(),
//                new CookieRequestCultureProvider(),
//                new RouteDataRequestCultureProvider(),
//                new CustomRequestCultureProvider(async context =>
//                {
//                    //Here logic to determine the culture
//                    //This example simulates getting the culture "es-ES" as the default.
//                    string culture = builder.Configuration["MultilanguageSettings:DefaultLanguage"];
                    
//                    return new ProviderCultureResult(culture);
//                })
//            };
//});

//---Filter
builder.Services.AddMvc(mvcOpts =>
{
    var defaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    mvcOpts.Filters.Add(new AuthorizeFilter(defaultPolicy));
    mvcOpts.Filters.Add(typeof(AutoLogAttribute));
}).AddControllersAsServices();

//--- CORS
builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()                  // Allow any origin (uses *)
           .AllowAnyMethod()                  // Allow all HTTP methods
           .AllowAnyHeader();                 // Allow all headers
                                              // Note: Cannot use AllowCredentials() with AllowAnyOrigin()
}));

//---Log
builder.Host.ConfigureDefaults(args).ConfigureLogging((hostingContext, logging) =>
{
    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    //logging.AddConsole();
    logging.AddDebug();
    //logging.AddEventSourceLogger();
    logging.AddNLog();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("MyPolicy");
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

//-----------------------
var supportedCultures = new[]
       {
            new CultureInfo("en-US"),
            new CultureInfo("vi-VN"),
            new CultureInfo("ja-JP"),
        };

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(builder.Configuration["MultilanguageSettings:DefaultLanguage"]),
    // Formatting numbers, dates, etc.
    SupportedCultures = supportedCultures,
    // UI strings that we have localized.
    SupportedUICultures = supportedCultures
});
//-----------------------
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
