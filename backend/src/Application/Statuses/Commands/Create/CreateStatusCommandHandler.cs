﻿using System.Threading;
using System.Threading.Tasks;
 using Application.Common.Interfaces;
 using Domain.Entities;
 using MediatR;

namespace Application.Statuses.Commands.Create
{
    public class CreateStatusCommandHandler : IRequestHandler<CreateStatusCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateStatusCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = new Status
            {
                Name = request.Name
            };
            
            await _context.Statuses.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}