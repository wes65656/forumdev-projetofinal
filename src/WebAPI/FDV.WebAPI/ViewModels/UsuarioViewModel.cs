using System;
using System.Globalization;
using FDV.Usuarios.App.Domain;


namespace FDV.WebAPI.ViewModels;

public class UsuarioViewModel
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string DataDeNascimento { get; set; }
    public string Foto { get; set; }

    public static UsuarioViewModel Mapear(Usuario usuario)
    {
        return new UsuarioViewModel()
        {
            Nome = usuario.Nome,
            DataDeNascimento = usuario.DataDeNascimento.ToString("G",new CultureInfo("pt-Br")),
            Foto = usuario.Foto,
            Cpf = usuario.Cpf.ObterNumeroFormatado()
        };
    }
}
