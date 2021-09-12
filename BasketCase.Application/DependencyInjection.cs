using BasketCase.Application.Commands.AddProductToBasket;
using BasketCase.Application.PipelineBehaviours;
using BasketCase.Application.Services;
using BasketCase.Application.Services.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BasketCase.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(AddProductToBasketCommand).GetTypeInfo().Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IBasketService, BasketService>();

            return services;
        }
    }
}
