﻿using BlogAPI.Src.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogAPI.Src.Repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de tema</para>
    /// <para>Criado por: Gabriel Marins</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 18/08/2022</para>
    /// </summary>

    public interface ITema
    {
        Task<List<Tema>> PegarTodosTemasAsync();
        Task<Tema> PegarTemaPeloIdAsync(int id);
        Task NovoTemaAsync(Tema tema);
        Task AtualizarTemaAsync(Tema tema);
        Task DeletarTemaAsync(int id);
    }

}
