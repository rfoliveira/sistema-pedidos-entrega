﻿using SisLog.Domain.Entities;
using SisLog.Domain.Repositories;
using SisLog.Infrastructure.Data;

namespace SisLog.Infrastructure.Repositories;

public class PedidoRepository(SisLogContext dbContext) : BaseRepository<Pedido>(dbContext), IPedidoRepository
{
}
