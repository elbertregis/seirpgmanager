// -----------------------------------------------------------------------
// <copyright file="Ocupacao.cs" company="Ludus Interactive">
// Todos os direitos reservados.
// </copyright>
// -----------------------------------------------------------------------
namespace SeiRPGManager.Entidades.Modelo.ClassesBasicas
{
    using System;
    using System.Collections.Generic;

    /// <summary>Classe respons�vel por gerenciar as ocupa��es que o personagem possui</summary>
	public class Ocupacao: Entidade
	{
		public string Nome { get; set; }

		public string Descricao { get; set; }
	}
}

