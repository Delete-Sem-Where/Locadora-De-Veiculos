using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculos
{
    public class Veiculos : EntidadeBase<Veiculos>
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public string Ano { get; set; }
        public string Cor { get; set; }
        public string TipoCombustivel { get; set; }
        public string QuilometroPercorrido { get; set; }
        public string CapacidadeTanque { get; set; }
        public Guid GrupoVeiculos_Id { get; set; }
       
        // public byte[] Foto { get; set; }

        //public override string ToString()
        //{
        //    return $" Modelo: {Modelo}, Marca: {Marca}, Ano: {Ano}, " +
        //            $"Cor: {Cor}, Placa: {Placa}, TipoCombustivel: {TipoCombustivel}, " +
        //            $"Km: {QuilometroPercorrido}, Capacidade Tanque: {CapacidadeTanque}, " +
        //            $"Grupo Veicular: {GrupoVeiculos};";
        //}

        public Veiculos Clonar()
        {
            return MemberwiseClone() as Veiculos;
        }

        public override bool Equals(object? obj)
        {
            Veiculos veiculos = obj as Veiculos;

            if (veiculos == null)
                return false;

            return
                veiculos.Id.Equals(Id) &&
                veiculos.Modelo.Equals(Modelo)&&
                veiculos.Marca.Equals(Marca) &&
                veiculos.Placa.Equals(Placa) &&
                veiculos.Ano.Equals(Ano) &&
                veiculos.Cor.Equals(Cor) &&
                veiculos.TipoCombustivel.Equals(TipoCombustivel) &&
                veiculos.QuilometroPercorrido.Equals(QuilometroPercorrido) &&
                veiculos.CapacidadeTanque.Equals(CapacidadeTanque) &&
                veiculos.GrupoVeiculos_Id.Equals(GrupoVeiculos_Id);
        }
    }
}
