using System;
using FDV.Core.Data;
using FDV.Usuarios.App.Domain;
using FDV.Usuarios.App.Domain.Interfaces;
using FDV.Usuarios.App.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace FDV.Usuarios.App.Infra.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly UsuarioContext _context;

    public UsuarioRepository(UsuarioContext context)
    {
        _context = context;
    }

    public IUnitOfWorks UnitOfWork => _context;

    public void Adicionar(Usuario entity)
    {
        _context.Usuarios.Add(entity);
    }

    public void Apagar(Func<Usuario, bool> predicate)
    {
        var usuarios = _context.Usuarios.Where(predicate).ToList();

        _context.Usuarios.RemoveRange(usuarios);
    }

    public void Atualizar(Usuario entity)
    {
       _context.Usuarios.Update(entity);
    }

    public async Task<Usuario> ObterPorId(Guid Id)
    {
        return await _context.Usuarios.FindAsync(Id);
    }
    
    public async Task<IEnumerable<Usuario>> ObterTodos()
    {
        return await _context.Usuarios.OrderBy(c => c.Nome).ToListAsync();
    }
    
    public void Dispose()
    {
        _context?.Dispose();
    }
}
