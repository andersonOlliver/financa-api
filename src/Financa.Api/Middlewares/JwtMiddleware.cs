﻿using AutoMapper;
using Financa.Domain.Dtos.Usuario;
using Financa.Domain.Interfaces.Repositories;
using Financa.Domain.Interfaces.Services;

namespace Financa.Api.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMapper _mapper;

        public JwtMiddleware(RequestDelegate next, IMapper mapper)
        {
            _next = next;
            _mapper = mapper;
        }

        public async Task Invoke(HttpContext context, IUsuarioRepository usuarioRepository, IJwtService jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId is not null)
            {
                context.Items["User"] = _mapper.Map<DetalhaUsuarioDto>(await usuarioRepository.ObterPorId(userId.Value));
            }

            await _next(context);
        }
    }
}
