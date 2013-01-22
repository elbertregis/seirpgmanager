// -----------------------------------------------------------------------
// <copyright file="Saude.cs" company="Ludus Interactive">
// Todos os direitos reservados.
// </copyright>
// -----------------------------------------------------------------------
namespace SeiRPGManager.Entidades.Modelo.ClassesBasicas
{
    using System;
    using System.Collections.Generic;

    /// <summary>Classe respons�vel por gerenciar o estado de sa�de dos personagens</summary>
	public class Saude: Entidade
	{
		public string Estado { get; set; }

		public string Descricao { get; set; }
	}
}

