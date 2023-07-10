using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using TestesDaDonaMariana.Dominio.ModuloQuestao;
using TestesDaDonaMariana.Dominio.ModuloTeste;

namespace TestesDaDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaGerarPdfTesteForm : Form
    {
        private Teste teste { get; set; }

        public TelaGerarPdfTesteForm(Teste teste)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.teste = teste;
        }

        public void ConfigurarTelaPdf(Teste teste)
        {
            txtTitulo.Text = teste.titulo.ToString().Trim();
        }

        private void GerarPdfGabarito()
        {
            PdfWriter localizacao = new PdfWriter(txtLocalizacao.Text + "/" + teste.id + "_gabarito" + ".pdf");
            PdfDocument pdf = new(localizacao); 
            Document doc = new(pdf);

            Paragraph header = new Paragraph("Gabarito do teste:")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(21);     

            Paragraph subheader = new Paragraph(teste.titulo)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(18)
                .SetBold();

            doc.Add(header);
            doc.Add(subheader);


            doc.Add(new LineSeparator(new SolidLine(1f)));
            doc.Add(new Paragraph(""));

            int i = 1;
            teste.questoes.ForEach(x =>
            {
                Paragraph questao = new Paragraph($"{i}) ")
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(11)
                    .SetBold();

                x.alternativas.Where(x => x.alternativaCorreta == AlternativaCorretaEnum.Correta).ToList().ForEach(y => questao.Add(new Text(y.ToString())));

                doc.Add(questao);

                i++;
            });

            doc.Add(new Paragraph(""));
            doc.Add(new LineSeparator(new SolidLine(1f)));
            doc.Close();
        }

        private void GerarPdfTeste()
        {
            PdfWriter localizacao = new PdfWriter(txtLocalizacao.Text + "/" + teste.id + ".pdf");
            PdfDocument pdf = new(localizacao);
            Document doc = new(pdf);

            doc.Add(new LineSeparator(new SolidLine(1f)));
            doc.Add(new Paragraph(""));

            Paragraph info = new Paragraph("• Teste:")
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(13);

            string materia = "";

            if (teste.materias.Count > 1)
                materia = "Todas";
            else
                materia = teste.materias.FirstOrDefault(x => x == teste.materias[0]).titulo;

            info.Add($"\n• Matéria: {materia}");

            doc.Add(info);
            doc.Add(new Paragraph(""));
            doc.Add(new LineSeparator(new SolidLine(1f)));
            doc.Add(new Paragraph("\n"));

            Paragraph title = new Paragraph(teste.titulo)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(21)
                .SetBold();

            doc.Add(title);
            doc.Add(new Paragraph("\n"));

            int i = 1;
            teste.questoes.ForEach(x =>
            {
                Paragraph questao = new Paragraph($"{i}) {x.enunciado}")
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(11)
                    .SetBold();

                doc.Add(questao);

                i++;

                x.alternativas.ForEach(y =>
                {
                    Paragraph alternative = new Paragraph(y.ToString())
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetFontSize(9);

                    doc.Add(alternative);
                });

                doc.Add(new Paragraph("\n"));

            });

            doc.Close();
        }

        private void btnGerarPDF_Click(object sender, EventArgs e)
        {
            if (txtLocalizacao.Text == null)
            {
                TelaPrincipalForm.Tela.AtualizarRodape($"Você deve informar a localização do diretório!");
                DialogResult = DialogResult.None;
                return;
            }
            if (!cbxTeste.Checked && !cbxGabarito.Checked)
            {
                TelaPrincipalForm.Tela.AtualizarRodape($"Você deve selecionar se gostaria do pdf do teste ou do gabarito!");
                DialogResult = DialogResult.None;
                return;
            }
            if (cbxTeste.Checked && !cbxGabarito.Checked)
            {
                GerarPdfTeste();
                return;
            }
            if (cbxGabarito.Checked && !cbxTeste.Checked)
            {
                GerarPdfGabarito();
                return;
            }
            if (cbxTeste.Checked && cbxGabarito.Checked)
            {
                GerarPdfTeste();
                GerarPdfGabarito();
                return;
            }

            MessageBox.Show("PDF gerado com sucesso!", "Gerar PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
            return;
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new();

            if (folder.ShowDialog() == DialogResult.OK)
                txtLocalizacao.Text = folder.SelectedPath;

            DialogResult = DialogResult.None;
        }
    }
}
