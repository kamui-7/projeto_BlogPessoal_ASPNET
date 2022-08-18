﻿using BlogAPI.Src.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogAPI.Src.Repositorios
{

    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de postagem</para>
    /// <para>Criado por: Gabriel Marins</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 18/08/2022</para>
    /// </summary>
    public interface IPostagem
    {
        Task<List<Postagem>> PegarTodasPostagensAsync();
        Task<Postagem> PegarPostagemPeloIdAsync(int id);
        Task NovaPostagemAsync(Postagem postagem);
        Task AtualizarPostagemAsync(Postagem postagem);
        Task DeletarPostagemAsync(int id);
    }

}
