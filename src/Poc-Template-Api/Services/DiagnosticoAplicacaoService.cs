using Poc_Template_Api.Services.Interface;
using Poc_Template_Api.ViewModel;
using System;
using System.Diagnostics;

namespace Poc_Template_Api.Services
{
    public class DiagnosticoAplicacaoService : IDiagnosticoAplicacaoService
    {
        public DiagnosticoAplicacaoModel ObterDiagnostico()
        {
            using var proc = Process.GetCurrentProcess();

            return new DiagnosticoAplicacaoModel
            {
                ProcessamentoAtual = $"{proc.WorkingSet64 * (9.537 * Math.Pow(10, -7)):F2} MB",
                MemoriaUsada = $"{proc.PrivateMemorySize64 * (9.537 * Math.Pow(10, -7)):F2} MB"
            };
        }
    }
}
