using System.Collections.Generic;
using GranjaAvicola.App.Domain;

namespace GranjaAvicola.App.Persistent
{
    public interface IRepoDiagnostico
    {
        IEnumerable<Diagnostico> GetAllDiagnostico();
        Diagnostico AddDiagnostico(Diagnostico Diagnostico);
        Diagnostico UpdateDiagnostico(Diagnostico Diagnostico);
        void DeleteDiagnostico(int idDiagnostico);
        Diagnostico GetDiagnostico(int idDiagnostico);
    }
}