﻿using System.Security.Cryptography;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.WinApp.ModuloQuestao
{
    public partial class TabelaAlternativasControl : UserControl
    {
        public TabelaAlternativasControl()
        {
            InitializeComponent();
            ConfigurarGridZebradoAlternativas(gridAlternativas);
            gridAlternativas.ConfigurarGridSomenteLeitura();
            gridAlternativas.Columns.AddRange(ObterColunas());

            TelaPrincipalForm.Tela.AtualizarRodape("");
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Descrição", HeaderText = "Descrição"},

                new DataGridViewTextBoxColumn { DataPropertyName = " ", HeaderText = " "}
            };

            return colunas;
        }

        public int ObterNumeroItemSelecionado()
        {
            return gridAlternativas.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Alternativa> alternativas)
        {
            gridAlternativas.Rows.Clear();

            foreach (var alternativa in alternativas)
            {
                gridAlternativas.Rows.Add(alternativa.texto, alternativa.alternativaCorreta);
            }
        }

        public static void ConfigurarGridZebradoAlternativas(DataGridView grid)
        {
            Font font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

            DataGridViewCellStyle linhaEscura = new DataGridViewCellStyle
            {
                BackColor = Color.RosyBrown,
                Font = font,
                ForeColor = Color.Black,
                SelectionBackColor = Color.Green,
                SelectionForeColor = Color.Black
            };

            grid.AlternatingRowsDefaultCellStyle = linhaEscura;

            DataGridViewCellStyle linhaClara = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                Font = font,
                ForeColor = Color.Black,
                SelectionBackColor = Color.Green,
                SelectionForeColor = Color.Black
            };

            grid.RowsDefaultCellStyle = linhaClara;
        }
    }
}