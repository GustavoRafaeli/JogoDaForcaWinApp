namespace JogoDaForcaWinApp
{
    public partial class Form1 : Form
    {
        Forca forca;
        int numErros = 0;
        public Form1()
        {
            InitializeComponent();
            forca = new Forca();
            ConfigurarBotoes();
            lblPalavra.Text = forca.palavraCriptografada;
        }

        private void ConfigurarBotoes()
        {
            btnA.Click += AtribuirLetra;
            btnB.Click += AtribuirLetra;
            btnC.Click += AtribuirLetra;
            btnD.Click += AtribuirLetra;
            btnE.Click += AtribuirLetra;
            btnF.Click += AtribuirLetra;
            btnG.Click += AtribuirLetra;
            btnH.Click += AtribuirLetra;
            btnI.Click += AtribuirLetra;
            btnJ.Click += AtribuirLetra;
            btnK.Click += AtribuirLetra;
            btnL.Click += AtribuirLetra;
            btnM.Click += AtribuirLetra;
            btnN.Click += AtribuirLetra;
            btnO.Click += AtribuirLetra;
            btnP.Click += AtribuirLetra;
            btnQ.Click += AtribuirLetra;
            btnR.Click += AtribuirLetra;
            btnS.Click += AtribuirLetra;
            btnT.Click += AtribuirLetra;
            btnU.Click += AtribuirLetra;
            btnV.Click += AtribuirLetra;
            btnW.Click += AtribuirLetra;
            btnX.Click += AtribuirLetra;
            btnY.Click += AtribuirLetra;
            btnZ.Click += AtribuirLetra;

            btnComecar.Click += Comecar;
        }

        private void Comecar(object? sender, EventArgs e)
        {
            forca.GerarPalavra();
            forca.LetrasEscolhidas.Clear();
            forca.ResetPalavraCriptografada();
            lblPalavra.Text = forca.palavraCriptografada;

            // Redefinir a cor de fundo dos botões das letras
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    if (button.Tag == null)
                    {
                        button.BackColor = Color.Maroon;
                    }
                }
            }
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    PictureBox pictureBox = (PictureBox)control;
                    pictureBox.Visible = false;
                }
            }
            picForca.Visible = true;
            numErros = 0;
            btnComecar.BackColor = Color.White;
        }
        private void AtribuirLetra(object? sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;
            char letra = botaoClicado.Text.ToUpper()[0];

            if (forca.LetrasEscolhidas.Contains(letra))
            {
                MessageBox.Show("Letra Repetida!");
                return;
            }

            forca.LetrasEscolhidas.Add(letra);

            if (forca.palavraRandom.Contains(letra))
            {
                for (int i = 0; i < forca.palavraRandom.Length; i++)
                {
                    if (forca.palavraRandom[i] == letra)
                    {
                        forca.palavraCriptografada = forca.palavraCriptografada.Substring(0, i) + letra + forca.palavraCriptografada.Substring(i + 1);
                    }
                }

                lblPalavra.Text = forca.palavraCriptografada;

                botaoClicado.BackColor = Color.SpringGreen;

                if (forca.palavraCriptografada == forca.palavraRandom)
                {
                    MessageBox.Show("Parabéns, você acertou a palavra!");
                }
            }
            else
            {
                botaoClicado.BackColor = Color.LightCoral;

                numErros++;

                switch (numErros)
                {
                    case 1:
                        picCabeca.Visible = true;
                        break;
                    case 2:
                        picCorpo.Visible = true;
                        break;
                    case 3:
                        picBracoDireito.Visible = true;
                        break;
                    case 4:
                        picBracoEsquerdo.Visible = true;
                        break;
                    case 5:
                        picPernaDireita.Visible = true;
                        break;

                    case 6:
                        picPernaEsquerda.Visible = true;
                        MessageBox.Show("Que pena, você perdeu! A palavra era " + forca.palavraRandom);
                        break;
                }
            }
        }
    }
}