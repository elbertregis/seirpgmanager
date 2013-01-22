// -----------------------------------------------------------------------
// <copyright file="Parametro.cs" company="Ludus Interactive">
// Todos os direitos reservados.
// </copyright>
// -----------------------------------------------------------------------
namespace SeiRPGManager.Entidades.Modelo.ClassesBasicas
{
    using System;
    using System.Collections.Generic;

    /// <summary>Classe respons�vel por gerenciar as parametriza��es do sistema</summary>
	public class Parametro: Entidade
	{
		public bool? PermitirTrilhaSonora { get; set; }

		public bool? ApenasRoladoresDados { get; set; }

		public bool? ResultadoDadosAvancado { get; set; }
	}
}



