// -----------------------------------------------------------------------
// <copyright file="Especializacao.cs" company="Ludus Interactive">
// Todos os direitos reservados.
// </copyright>
// -----------------------------------------------------------------------
namespace SeiRPGManager.Entidades.Modelo.ClassesBasicas
{
    using System;
    using System.Collections.Generic;

    /// <summary>Classe respons�vel por gerenciar as especializa��es dos habilitadores especiais das ra�as do SubMundo</summary>
	public class Especializacao: Entidade
	{
        public long HabilitadorId { get; set; }

		public string Nome { get; set; }

		public string Descricao { get; set; }

		public virtual Habilitador Habilitador { get; set; }
	}
}

