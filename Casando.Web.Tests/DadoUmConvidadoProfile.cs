using System;
using System.Collections.Generic;
using AutoMapper;
using Casando.Core.Modelos;
using Casando.Web.ViewModels.Convidado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Casando.Web.Mappers;

namespace Casando.Web.Tests
{
    [TestClass]
    public class DadoUmConvidadoProfile
    {
        [TestMethod]
        public void AoConverterCadastrarConvidadoVMEmConvidadoOSobrenomeDeveSerAlgo()
        {
            Mapper.AddProfile<ConvidadoProfile>();

            var nomesESobrenomes = new Dictionary<string, string>
            {
                {"Pedro Benvides Botelho","Benvides Botelho"},
                {"José Alberto Monteiro Albuquerque","Monteiro Albuquerque"},
                {"Myrelle Firmino Coura Benvides","Coura Benvides"},

            };

            foreach (var nomesESobrenome in nomesESobrenomes)
            {
                var convidadoVM = new CadastrarConvidadoVM();
                convidadoVM.Nome = nomesESobrenome.Key;
                var convidado = Mapper.Map<Convidado>(convidadoVM);

                Assert.AreEqual(nomesESobrenome.Value, convidado.Sobrenome);
            }
        }
    }
}
