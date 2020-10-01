using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

        IMedicoRepository MedicoRepository { get; }
        IAtendimentoRepository AtendimentoRepository { get; }
        IPacienteRepository PacienteRepository { get; }
    }
}
