﻿using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Catalogo.Data;
using NerdStore.Catalogo.Data.Repository;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Events;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Application.Events;
using NerdStore.Vendas.Data;
using NerdStore.Vendas.Data.Repository;
using NerdStore.Vendas.Domain;

namespace NerdStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Domain Notifications
            services.AddScoped<ICanHandleNotification<DomainNotification>, DomainNotificationHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();
            // Catalogo Events Handler
            services.AddScoped<ICanHandleEvent<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();
            services.AddScoped<ICanHandleEvent<ProdutoMaximoEstoqueEvent>, ProdutoEventHandler>();

            // Vendas
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<VendasContext>();
            // Vendas Commands Handler
            services.AddScoped<ICanHandleCommand<AdicionarItemPedidoCommand>  , PedidoCommandHandler>();
            services.AddScoped<ICanHandleCommand<AplicarVoucherPedidoCommand> , PedidoCommandHandler>();
            services.AddScoped<ICanHandleCommand<AtualizarItemPedidoCommand>  , PedidoCommandHandler>();
            services.AddScoped<ICanHandleCommand<RemoverItemPedidoCommand>    , PedidoCommandHandler>();
            // Vendas Events Handler
            services.AddScoped<ICanHandleEvent<PedidoRascunhoIniciadoEvent>   , PedidoEventHandler>();
            services.AddScoped<ICanHandleEvent<PedidoAtualizadoEvent>         , PedidoEventHandler>();
            services.AddScoped<ICanHandleEvent<PedidoItemAdicionadoEvent>     , PedidoEventHandler>();
        }
    }
}
