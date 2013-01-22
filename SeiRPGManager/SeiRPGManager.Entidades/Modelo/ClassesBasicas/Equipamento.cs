// -----------------------------------------------------------------------
// <copyright file="Equipamento.cs" company="Ludus Interactive">
// Todos os direitos reservados.
// </copyright>
// -----------------------------------------------------------------------
namespace SeiRPGManager.Entidades.Modelo.ClassesBasicas
{
    using System;
    using System.Collections.Generic;
    using SeiRPGManager.Entidades.Modelo.Enum;

    /// <summary>Classe respons�vel por gerenciar os equipamento que ser�o carregados pelos personagens</summary>
	public class Equipamento: Entidade
	{
		public string Nome { get; set; }

		public string Descricao { get; set; }

        public Ajuste? AjusteEnum
        {
            get { return (Ajuste?)Ajuste; }
            set { Ajuste = (int?)value; }
        }

        private int? Ajuste { get; set; }

		public byte[] Imagem { get; set; }
	}
}

