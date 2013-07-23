// -----------------------------------------------------------------------
// <copyright file="SeiRPGManagerDAO.cs" company="Playware">
// Todos os direitos reservados.
// </copyright>
// -----------------------------------------------------------------------
namespace SeiRPGManager.DAL.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    using SeiRPGManager.Entidades.Modelo.ClassesBasicas;
    using SeiRPGManager.DAL.Repositorio.Interface;
    using Storytelling.Negocio.Excecoes;
    using System.Data.Objects;
    using System.Data.Entity.Infrastructure;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SeiRPGManagerDAO<T> : ISeiRPGManagerDAO<T> where T : Entidade
    {
        /// <summary>
        /// 
        /// </summary>
        internal SeiRPGManagerContexto _contexto;

        /// <summary>
        /// 
        /// </summary>
        public SeiRPGManagerDAO()
        {
            this._contexto = new SeiRPGManagerContexto();
        }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        /// <returns>TODO: Update Header</returns>
        public List<T> ObterTodos<T>() where T : Entidade
        {
            try
            {
                using (var contexto = new SeiRPGManagerContexto())
                {
                    if (contexto.Set<T>().Any() == false)
                    {
                        return null;
                    }
                    else
                    {
                        return contexto.Set<T>().Select(x => x).ToList<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        /// <param name="contexto"></param>
        /// <returns></returns>
        public bool SalvarContexto()
        {
            try
            {
                bool retorno = false;

                if (_contexto.SaveChanges() == 1)
                {
                    retorno = true;
                }

                return retorno;
            }
            catch (UpdateException ex)
            {
                if (ex.InnerException.Message.IndexOf("UNIQUE KEY") > -1)
                {
                    throw new ViolacaoChaveUnicaException(ex.InnerException);
                }
                else
                {
                    throw new ViolacaoReferenciaException(ex.InnerException);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entidade"></param>
        public void Atualizar<T>(T entidade) where T : Entidade
        {
            using (var contexto = new SeiRPGManagerContexto())
            {
                contexto.Set<T>().Attach(entidade);
                _contexto.Entry(entidade).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        public void Excluir<T>(params long[] ids) where T : Entidade
        {
            if (ids == null || ids.Count() == 0)
                throw new ArgumentException("Impossível excluir uma entidade nula");

            using (var contexto = new SeiRPGManagerContexto())
            {
                T entityToDelete = contexto.Set<T>().Where(ent => ent.Id == 1).Single();
                T entidade;

                foreach (long id in ids)
                {
                    entidade = ObterUm<T>(ent => ent.Id == id);
                    Excluir<T>(entidade);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public IEnumerable<T> Pesquisar<T>(Func<T, bool> filtro) where T : Entidade
        {
            using (var contexto = new SeiRPGManagerContexto())
            {
                return contexto.Set<T>().Where(filtro);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public T ObterUm<T>(Func<T, bool> filtro) where T : Entidade
        {
            using (var contexto = new SeiRPGManagerContexto())
            {
                return contexto.Set<T>().Single(filtro);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public T ObterPrimeiro<T>(Func<T, bool> filtro) where T : Entidade
        {
            using (var contexto = new SeiRPGManagerContexto())
            {
                return contexto.Set<T>().First(filtro);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> Pesquisar<T>() where T : Entidade
        {
            using (var contexto = new SeiRPGManagerContexto())
            {
                return contexto.Set<T>().ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entidade"></param>
        public void Inserir<T>(T entidade) where T : Entidade
        {
            if (entidade == null)
                throw new ArgumentException("Impossível inserir uma entidade Nula");

            using (var contexto = new SeiRPGManagerContexto())
            {
                contexto.Set<T>().Add(entidade);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entidade"></param>
        public void Excluir<T>(T entidade) where T : Entidade
        {
            if (entidade == null)
                throw new ArgumentException("Impossível excluir uma entidade nula");

            using (var contexto = new SeiRPGManagerContexto())
            {
                if (contexto.Entry(entidade).State == EntityState.Detached)
                {
                    contexto.Set<T>().Attach(entidade);
                }
                contexto.Set<T>().Remove(entidade);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entidade"></param>
        public void Anexar<T>(T entidade) where T : Entidade
        {
            if (entidade == null)
                throw new ArgumentException("Impossível anexar a uma entidade nula");

            using (var contexto = new SeiRPGManagerContexto())
            {
                contexto.Set<T>().Attach(entidade);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
